using System.Threading;
using Core.StateMachine;
using Cysharp.Threading.Tasks;
using VContainer.Unity;

namespace Game
{
    public class GameEntryPoint : IStartable
    {
        private readonly IStatesController<GameState> _statesController;

        public GameEntryPoint(IStatesController<GameState> statesController)
        {
            _statesController = statesController;
        }

        public void Start()
        {
            StartAsync().Forget();
        }

        private async UniTask StartAsync()
        {
            await _statesController.EnterStateAsync(GameState.Splash, CancellationToken.None);
        }
    }
}