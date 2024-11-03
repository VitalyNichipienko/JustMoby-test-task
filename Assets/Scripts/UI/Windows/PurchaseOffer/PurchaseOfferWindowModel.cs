using Core.Data.Offers;
using UnityEngine;
using Zenject;

namespace UI.Windows.PurchaseOffer
{
    public class PurchaseOfferWindowModel
    {
        private readonly OffersContainer _offersContainer;
        
        public OfferEntity CurrentOffer { get; private set; }

        [Inject]
        public PurchaseOfferWindowModel(OffersContainer offersContainer)
        {
            _offersContainer = offersContainer;
        }

        public void UpdateOffer()
        {
            var offersArray = _offersContainer.OfferEntities;

            if (offersArray.Count > 0)
            {
                var randomIndex = Random.Range(0, offersArray.Count);
                CurrentOffer = offersArray[randomIndex];
            }
            else
            {
                Debug.LogError($"[{typeof(PurchaseOfferWindowModel)}] OfferEntities array is empty");
            }
        }

        public void BuyOffer()
        {
            if (CurrentOffer != null)
            {
                Debug.Log($"[{typeof(PurchaseOfferWindowModel)}] Offer purchased: {CurrentOffer.OfferId}");
            }
            else
            {
                Debug.LogError($"[{typeof(PurchaseOfferWindowModel)}] No active offer available to purchase");
            }
        }
    }
}