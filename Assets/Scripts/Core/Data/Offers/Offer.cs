using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Data.Offers
{
    [Serializable]
    public class Offer
    {
        [field: SerializeField] public string OfferName { get; private set; }
        [field: SerializeField] public string OfferDescription { get; private set; }
        [field: SerializeField] public string OfferIconName { get; private set; }

        [field: Space]
        [field: SerializeField] public int RegularPrice { get; private set; }
        [field: SerializeField] public int DiscountPercentage { get; private set; }
        [field: SerializeField] public bool IsDiscountActive { get; private set; }

        [Space] [SerializeField] private List<ItemInOffer> _items;

        public IReadOnlyList<ItemInOffer> Items => _items;
        public int DiscountPrice => IsDiscountActive 
            ? RegularPrice - (RegularPrice * DiscountPercentage / 100) 
            : RegularPrice;
    }
}