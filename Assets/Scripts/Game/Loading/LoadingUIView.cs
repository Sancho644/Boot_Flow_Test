using Core.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Loading
{
    public class LoadingUIView : AbstractUIViewT<LoadingViewModel>
    {
        [SerializeField] private Image progressBar;

        public Image ProgressBar => progressBar;
        
        public override void Initialize()
        {
            Debug.Log("Initialize UIView");
        }

        public override void Release()
        {
            Debug.Log("Dispose UIView");
        }
    }
}