using System.Collections.Generic;
using Core.Data.Game;
using Core.Data.Offers;
using Core.Infrastructure;
using Core.Infrastructure.Services.ResourceLoader;
using TMPro;
using UI.Buttons;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Windows.PurchaseOffer
{
    public class PurchaseOfferWindowView : Window
    {
        [field: SerializeField] public PurchaseButton PurchaseButton { get; private set; }
        
        [SerializeField] private TextMeshProUGUI _headerText;
        [SerializeField] private TextMeshProUGUI _descriptionText;
        [SerializeField] private Image _offerImage;
        [SerializeField] private Transform _gridContentTransform;

        [Space]
        [SerializeField] private PurchaseItem _purchaseItemPrefab;
        
        private CommonFactory _commonFactory;
        private GameData _gameData;
        private ResourceLoaderService _resourceLoaderService;

        private readonly List<PurchaseItem> _createdPurchaseItems = new List<PurchaseItem>();

        [Inject]
        private void Construct(CommonFactory commonFactory, GameData gameData, ResourceLoaderService resourceLoaderService)
        {
            _commonFactory = commonFactory;
            _gameData = gameData;
            _resourceLoaderService = resourceLoaderService;
        }
        
        public async void UpdateView(Offer offer)
        {
            _headerText.text = offer.OfferName;
            _descriptionText.text = offer.OfferDescription;
            _offerImage.sprite = await _resourceLoaderService.LoadSpriteAsync(offer.OfferIconName);
            
            var itemCountInOffer = _gameData.ItemCountInOffer;
            var offerItemsCount = offer.Items.Count;
            
            PurchaseButton.Initialize(offer.DiscountPrice, offer.RegularPrice, offer.DiscountPercentage, offer.IsDiscountActive);

            for (var i = 0; i < itemCountInOffer; i++)
            {
                var randomIndex = Random.Range(0, offerItemsCount);
                var item = offer.Items[randomIndex];
                
                var purchaseItem = _commonFactory.Instantiate(_purchaseItemPrefab, _gridContentTransform);
                purchaseItem.Initialize(item.ItemData.IconName, item.ItemCount);
                
                _createdPurchaseItems.Add(purchaseItem);
            }
        }

        public override void Hide()
        {
            for (var i = 0; i < _createdPurchaseItems.Count; i++)
            {
                Destroy(_createdPurchaseItems[i].gameObject);
            }
            
            _createdPurchaseItems.Clear();
            base.Hide();
        }
    }
}
