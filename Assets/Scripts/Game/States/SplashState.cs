using System.Threading;
using Core.StateMachine;
using Cysharp.Threading.Tasks;
using Game.Settings;
using Game.Splash;

namespace Game.States
{
    public class SplashState : IState
    {
        private readonly SplashSettings _settings;
        private readonly SplashViewModel _viewModel;
        private readonly IStatesController<GameState> _statesController;

        public SplashState(SplashViewModel viewModel, SplashSettings settings, IStatesController<GameState> statesController)
        {
            _viewModel = viewModel;
            _settings = settings;
            _statesController = statesController;
        }

        public async UniTask EnterAsync(CancellationToken ct)
        {
            _viewModel.Initialize();

            await UniTask.Delay(_settings.DelayMs, cancellationToken: ct);

            await _statesController.EnterStateAsync(GameState.Load, ct);
        }

        public UniTask ExitAsync(CancellationToken ct)
        {
            _viewModel.Release();
            
            return UniTask.CompletedTask;
        }
    }
}