using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Core.StateMachine
{
    public class StatesController<TEnum> : IStatesController<TEnum>
    {
        private readonly Dictionary<TEnum, IState> _states = new();

        private IState _currentState;

        public void RegisterState(TEnum code, IState state) => _states[code] = state;

        public async UniTask EnterStateAsync(TEnum code, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            if (!_states.TryGetValue(code, out var state))
            {
                throw new System.Exception($"State {code} not registered");
            }

            if (_currentState != null && _currentState.Equals(state))
            {
                return;
            }

            if (_currentState != null)
            {
                await _currentState.ExitAsync(ct);
            }

            _currentState = state;
            
            await _currentState.EnterAsync(ct);
        }
    }
}