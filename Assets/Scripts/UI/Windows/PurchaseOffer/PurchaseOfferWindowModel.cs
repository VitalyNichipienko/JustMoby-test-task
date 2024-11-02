using Core.Data;
using UnityEngine;
using Zenject;

namespace UI.Windows.PurchaseOffer
{
    public class PurchaseOfferWindowModel// : IInitializable
    {
        private GameData _gameData;
        private OffersContainer _offersContainer;
        
        public OfferEntity CurrentOffer { get; private set; }

        [Inject]
        public PurchaseOfferWindowModel(OffersContainer offersContainer, GameData gameData)
        {
            _gameData = gameData;
            _offersContainer = offersContainer;
            
            Initialize();
        }

        public void Initialize()
        {
            var offersArray = _offersContainer.OfferEntities;

            if (offersArray.Count > 0)
            {
                var randomIndex = Random.Range(0, offersArray.Count);
                CurrentOffer = offersArray[randomIndex];
            }
            else
            {
                Debug.LogWarning("OfferEntities array is empty.");
            }
        }
    }
}