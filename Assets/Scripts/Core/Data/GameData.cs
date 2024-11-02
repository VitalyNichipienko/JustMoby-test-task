using UnityEngine;

namespace Core.Data
{
    public class GameData
    {
        private int _itemCountInOffer;

        public int ItemCountInOffer
        {
            get => _itemCountInOffer;
            set => _itemCountInOffer = Mathf.Clamp(value, 3, 6);
        }
    }
}
