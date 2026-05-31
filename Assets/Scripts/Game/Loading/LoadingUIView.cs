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
        }

        public void Bind(ReactiveValue<float> reactiveValue)
        {
            _disposables.Add(reactiveValue.Subscribe(SetProgress));
        }

        private void SetProgress(float value)
        {
            progressBar.fillAmount = value;
        }

        public override void Release()
        {
            Debug.Log("Dispose UIView");

            _disposables?.Dispose();
            _disposables = null;
        }
    }
}