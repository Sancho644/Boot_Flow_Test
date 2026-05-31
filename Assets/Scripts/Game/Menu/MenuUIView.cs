using System;
using Core.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Menu
{
    public class MenuUIView : AbstractUIViewT<MenuViewModel>
    {
        [SerializeField] private Button restartButton;

        public event Action OnRestartClicked;

        public override void Initialize()
        {
            Debug.Log("Initialize UIView");
            
            restartButton.onClick.AddListener(OnRestart);
        }

        public override void Release()
        {
            Debug.Log("Dispose UIView");
            
            restartButton.onClick.RemoveListener(OnRestart);
        }

        private void OnRestart()
        {
            OnRestartClicked?.Invoke();
        }
    }
}