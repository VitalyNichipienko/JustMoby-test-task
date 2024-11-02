using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Data
{
    [Serializable]
    public class Offer
    {
        [field: SerializeField] public string OfferName { get; private set; }
        [field: SerializeField] public string OfferDescription { get; private set; }
        [field: SerializeField] public string OfferIconName { get; private set; }

        [field: Space]
        [field: SerializeField] public float RegularPrice { get; private set; }
        [field: SerializeField] public float DiscountPercentage { get; private set; }
        [field: SerializeField] public bool IsDiscountActive { get; private set; }

        [field: Space] [field: SerializeField] private List<ItemData> _items;

        public IReadOnlyList<ItemData> Items => _items;
    }
}