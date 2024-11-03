using System;
using UnityEngine;

namespace Core.Data.Offers
{
    [CreateAssetMenu(menuName = "Items/Create item data", fileName = "ItemData")]
    [Serializable]
    public class ItemData : ScriptableObject
    {
        [field: SerializeField] public string ItemName { get; private set; }
        [field: SerializeField] public string IconName { get; private set; }
    }
}