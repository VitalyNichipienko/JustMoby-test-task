using System.Collections.Generic;
using UnityEngine;

namespace Core.Data.Offers
{
    [CreateAssetMenu(menuName = "Containers/Create offers container", fileName = "OffersContainer")]
    public class OffersContainer : ScriptableObject
    {
        [SerializeField] private List<OfferEntity> _offerEntities = null!;

        public IReadOnlyList<OfferEntity> OfferEntities => _offerEntities;
    }
}