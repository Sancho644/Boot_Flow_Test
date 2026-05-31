using Core.UI;
using UnityEngine;

namespace Game.Splash
{
    public class SplashUIView : AbstractUIViewT<SplashViewModel>
    {
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