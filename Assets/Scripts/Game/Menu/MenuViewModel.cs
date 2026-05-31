using System;
using Core.UI;

namespace Game.Menu
{
    public class MenuViewModel : IUIViewModel
    {
        private readonly MenuUIView _view;

        public event Action OnRestartClicked;

        public MenuViewModel(MenuUIView view)
        {
            _view = view;
        }

        public void Initialize()
        {
            _view.RestartButton.onClick.AddListener(OnRestart);
            _view.Initialize();
            
            _view.gameObject.SetActive(true);
        }

        public void Release()
        {
            _view.RestartButton.onClick.RemoveListener(OnRestart);
            _view.Release();
            
            _view.gameObject.SetActive(false);
        }

        private void OnRestart()
        {
            OnRestartClicked?.Invoke();
        }
    }
}