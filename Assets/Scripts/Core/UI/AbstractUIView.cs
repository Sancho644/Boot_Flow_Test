using UnityEngine;

namespace Core.UI
{
    public abstract class AbstractUIView : MonoBehaviour
    {
        public abstract void Initialize();
        public abstract void Release();
    }
}