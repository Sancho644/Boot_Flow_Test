using System.Threading;
using Core.Reactive;
using Core.StateMachine;
using Cysharp.Threading.Tasks;
using Game.Loading;
using Game.Settings;

namespace Game.States
{
    public class LoadState : IState
    {
        private ReactiveValue<float> Progress { get; } = new(0f);

        private readonly LoadingUIView _view;
        private readonly LoadingSettings _settings;
        private readonly IStatesController<GameState> _statesController;

        public LoadState(LoadingUIView view, LoadingSettings settings, IStatesController<GameState> statesController)
        {
            _view = view;
            _settings = settings;
            _statesController = statesController;
        }

        public async UniTask EnterAsync(CancellationToken ct)
        {
            Progress.Value = 0f;

            _view.Initialize();
            _view.Bind(Progress);
            _view.gameObject.SetActive(true);

            for (var i = 0; i < _settings.Steps; i++)
            {
                ct.ThrowIfCancellationRequested();

                await UniTask.Delay(_settings.StepsDelayMs, cancellationToken: ct);

                if (_settings.Steps <= 0)
                {
                    throw new System.Exception("Steps must be greater than 0");
                }

                Progress.Value = (i + 1f) / _settings.Steps;
            }

            await _statesController.EnterStateAsync(GameState.Menu, ct);
        }

        public UniTask ExitAsync(CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            _view.Release();
            _view.gameObject.SetActive(false);

            return UniTask.CompletedTask;
        }
    }
}