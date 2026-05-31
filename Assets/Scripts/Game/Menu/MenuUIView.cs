using Core.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Menu
{
    public class MenuUIView : AbstractUIViewT<MenuViewModel>
    {
        [SerializeField] public Button restartButton;

        public Button RestartButton => restartButton;

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