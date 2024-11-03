using UI.Configurations;
using UnityEngine;
using Zenject;

namespace Core.Data.Game
{
    public class GameData
    {
        private int _itemCountInOffer;

        public int MinItemCount { get; }
        public int MaxItemCount { get; }

        public int ItemCountInOffer
        {
            get => _itemCountInOffer;
            set => _itemCountInOffer = Mathf.Clamp(value, MinItemCount, MaxItemCount);
        }

        [Inject]
        public GameData(OfferConfiguration offerConfiguration)
        {
            MinItemCount = offerConfiguration.MinItemCount;
            MaxItemCount = offerConfiguration.MaxItemCount;
        }
    }
}