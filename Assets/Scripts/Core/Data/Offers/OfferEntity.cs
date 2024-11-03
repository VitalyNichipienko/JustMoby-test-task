using System;
using UnityEngine;

namespace Core.Data.Offers
{
    [Serializable]
    public class OfferEntity
    {
        [field: SerializeField] public string OfferId { get; private set; }
        [field: SerializeField] public Offer Offer { get; private set; }
    }
}