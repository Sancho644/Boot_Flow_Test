using System.Threading;
using Core.StateMachine;
using Cysharp.Threading.Tasks;
using Game.Settings;
using Game.Splash;

namespace Game.States
{
    public class SplashState : IState
    {
        private readonly SplashUIView _view;
        private readonly SplashSettings _settings;
        private readonly IStatesController<GameState> _statesController;

        public SplashState(SplashUIView view, SplashSettings settings, IStatesController<GameState> statesController)
        {
            _view = view;
            _settings = settings;
            _statesController = statesController;
        }

        public async UniTask EnterAsync(CancellationToken ct)
        {
            _view.Initialize();
            _view.gameObject.SetActive(true);

            await UniTask.Delay(_settings.DelayMs, cancellationToken: ct);

            await _statesController.EnterStateAsync(GameState.Load, ct);
        }

        public UniTask ExitAsync(CancellationToken ct)
        {
            _view.Release();
            _view.gameObject.SetActive(false);

            return UniTask.CompletedTask;
        }
    }
}