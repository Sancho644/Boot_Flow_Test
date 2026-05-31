using System.Threading;
using Core.StateMachine;
using Cysharp.Threading.Tasks;
using Game.Menu;

namespace Game.States
{
    public class MenuState : IState
    {
        private readonly MenuUIView _view;
        private readonly IStatesController<GameState> _statesController;

        public MenuState(MenuUIView view, IStatesController<GameState> statesController)
        {
            _view = view;
            _statesController = statesController;
        }

        public UniTask EnterAsync(CancellationToken ct)
        {
            _view.Initialize();
            _view.gameObject.SetActive(true);

            _view.OnRestartClicked += HandleRestartClicked;

            return UniTask.CompletedTask;
        }

        public UniTask ExitAsync(CancellationToken ct)
        {
            _view.OnRestartClicked -= HandleRestartClicked;

            _view.Release();
            _view.gameObject.SetActive(false);

            return UniTask.CompletedTask;
        }

        private void HandleRestartClicked()
        {
            _statesController.EnterStateAsync(GameState.Load, CancellationToken.None).Forget();
        }
    }
}