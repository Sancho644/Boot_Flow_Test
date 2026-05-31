using System.Threading;
using Core.StateMachine;
using Cysharp.Threading.Tasks;
using Game.Menu;

namespace Game.States
{
    public class MenuState : IState
    {
        private readonly MenuViewModel _viewModel;
        private readonly IStatesController<GameState> _statesController;

        public MenuState(MenuViewModel viewModel, IStatesController<GameState> statesController)
        {
            _viewModel = viewModel;
            _statesController = statesController;
        }

        public UniTask EnterAsync(CancellationToken ct)
        {
            _viewModel.Initialize();

            _viewModel.OnRestartClicked += HandleRestartClicked;

            return UniTask.CompletedTask;
        }

        public UniTask ExitAsync(CancellationToken ct)
        {
            _viewModel.OnRestartClicked -= HandleRestartClicked;

            _viewModel.Release();

            return UniTask.CompletedTask;
        }

        private void HandleRestartClicked()
        {
            _statesController.EnterStateAsync(GameState.Load, CancellationToken.None).Forget();
        }
    }
}