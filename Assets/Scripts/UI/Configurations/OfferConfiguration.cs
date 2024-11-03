using UnityEngine;

namespace UI.Configurations
{
    [CreateAssetMenu(menuName = "Configurations/Create offer configuration", fileName = "OfferConfiguration")]
    public class OfferConfiguration : ScriptableObject
    {
        [field: SerializeField] public int MinItemCount { get; private set; }
        [field: SerializeField] public int MaxItemCount { get; private set; }
    }
}