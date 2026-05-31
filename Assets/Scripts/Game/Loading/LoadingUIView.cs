using Core.Reactive;
using Core.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Loading
{
    public class LoadingUIView : AbstractUIViewT<LoadingViewModel>
    {
        [SerializeField] private Image progressBar;

        private CompositeDisposable _disposables;

        public override void Initialize()
        {
            Debug.Log("Initialize UIView");

            _disposables = new CompositeDisposable();

            Bind(ViewModel);
        }

        public override void Release()
        {
            Debug.Log("Dispose UIView");

            _disposables?.Dispose();
            _disposables = null;
        }

        private void SetProgress(float value)
        {
            if (progressBar != null)
                progressBar.fillAmount = value;
        }

        private void Bind(LoadingViewModel vm)
        {
            _disposables.Add(vm.SmoothedProgress.Subscribe(SetProgress));
        }
    }
}