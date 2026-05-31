using System.Threading;
using Core.Reactive;
using Core.UI;
using Cysharp.Threading.Tasks;
using Game.Settings;
using UnityEngine;

namespace Game.Loading
{
    public class LoadingViewModel : IUIViewModel
    {
        public ReactiveValue<float> TargetProgress { get; } = new(0f);
        public ReactiveValue<float> SmoothedProgress { get; } = new(0f);
        
        private readonly LoadingUIView _view;
        private readonly LoadingSettings _settings;

        private CancellationTokenSource _updateCts; 
        private CompositeDisposable   _disposables; 

        public LoadingViewModel(LoadingUIView view, LoadingSettings settings)
        {
            _view = view;
            _settings = settings;
        }

        public void Initialize()
        {
            TargetProgress.Value = 0f;
            SmoothedProgress.Value = 0f;
            
            _disposables = new CompositeDisposable();
            _updateCts   = new CancellationTokenSource();
            
            _ = UpdateLoopAsync(_updateCts.Token);
            
            _view.Initialize(); 
            _view.gameObject.SetActive(true); 
        }

        public void Release()
        {
            _updateCts?.Cancel();
            _updateCts?.Dispose();
            _updateCts = null;
            
            _disposables?.Dispose();
            _disposables = null;
            
            _view.Release(); 
            _view.gameObject.SetActive(false); 
        }

        public void Bind(ReactiveValue<float> reactiveValue)
        {
            _disposables.Add(reactiveValue.Subscribe(value =>
            {
                TargetProgress.Value = value;
            }));
        }

        private async UniTask UpdateLoopAsync(CancellationToken ct)
        {
            while (!ct.IsCancellationRequested)
            {
                var cur  = SmoothedProgress.Value;
                var tgt  = TargetProgress.Value;
                var next = Mathf.Lerp(cur, tgt, _settings.LerpSpeed * Time.unscaledDeltaTime);
                
                if (cur != 0 && tgt != 0 && Mathf.Abs(cur - tgt) < 0.001f)
                {
                    SmoothedProgress.Value = tgt;
                    break;
                }
                
                SmoothedProgress.Value = next;
                
                await UniTask.Yield(PlayerLoopTiming.Update, ct);
            }
        }
    }
}