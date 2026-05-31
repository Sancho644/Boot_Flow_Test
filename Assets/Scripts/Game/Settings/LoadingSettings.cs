using UnityEngine;

namespace Game.Settings
{
    [CreateAssetMenu(menuName = "Configs/LoadingSettings")]
    public class LoadingSettings : ScriptableObject
    {
        [field: SerializeField] public int Steps { get; private set; } = 5;
        [field: SerializeField] public int StepsDelayMs { get; private set; } = 200;
        [field: SerializeField] public float LerpSpeed { get; private set; } = 8f;
    }
}