using UnityEngine;

namespace Game.Settings
{
    [CreateAssetMenu(menuName = "Configs/SplashSettings")]
    public class SplashSettings : ScriptableObject
    {
        [field: SerializeField] public int DelayMs { get; private set; } = 1000;
    }
}