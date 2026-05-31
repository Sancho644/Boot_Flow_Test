using Core.Reactive;
using Core.UI;

namespace Game.Loading
{
    public class LoadingViewModel : IUIViewModel
    {
        private readonly LoadingUIView _view;

        private CompositeDisposable _disposables;

        public LoadingViewModel(LoadingUIView view)
        {
            _view = view;
        }

        public void Initialize()
        {
            _disposables = new CompositeDisposable();
            _view.gameObject.SetActive(true);
        }

        public void Bind(ReactiveValue<float> reactiveValue)
        {
            _disposables.Add(reactiveValue.Subscribe(SetProgress));
        }

        public void Release()
        {
            _disposables?.Dispose();
            _disposables = null;
            
            _view.gameObject.SetActive(false);
        }

        private void SetProgress(float value)
        {
            _view.ProgressBar.fillAmount = value;
        }
    }
}