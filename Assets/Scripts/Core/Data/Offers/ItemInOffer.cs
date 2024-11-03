using System;
using UnityEngine;

namespace Core.Data.Offers
{
    [Serializable]
    public class ItemInOffer
    {
        [field: SerializeField] public ItemData ItemData { get; private set; }
        [field: SerializeField] public int ItemCount { get; private set; }
    }
}