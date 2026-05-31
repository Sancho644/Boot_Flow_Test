using Core.UI;

namespace Game.Splash
{
    public class SplashViewModel : IUIViewModel
    {
        private readonly SplashUIView _view;

        public SplashViewModel(SplashUIView view)
        {
            _view = view;
        }
        
        public void Initialize()
        {
            _view.Initialize();
            
            _view.gameObject.SetActive(true);
        }

        public void Release()
        {
            _view.Release();
            
            _view.gameObject.SetActive(false);
        }
    }
}