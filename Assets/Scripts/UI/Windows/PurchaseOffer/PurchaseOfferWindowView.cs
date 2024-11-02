using Core.Data;
using Core.Infrastructure;
using TMPro;
using UI.Buttons;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Windows.PurchaseOffer
{
    public class PurchaseOfferWindowView : Window
    {
        [SerializeField] private TextMeshProUGUI _headerText;
        [SerializeField] private TextMeshProUGUI _descriptionText;
        [SerializeField] private Image _offerImage;
        [SerializeField] private Transform _gridContentTransform;
        [SerializeField] private PurchaseButton _purchaseButton;

        [SerializeField] private PurchaseItem _purchaseItemPrefab;
        
        private CommonFactory _commonFactory;

        [Inject]
        private void Construct(CommonFactory commonFactory)
        {
            _commonFactory = commonFactory;
        }
        
        public void UpdateView(Offer offer)
        {
            _headerText.text = offer.OfferName;
            _descriptionText.text = offer.OfferDescription;
            //_offerImage.sprite = icon;

            foreach (var item in offer.Items)
            {
                var purchaseItem = _commonFactory.Instantiate(_purchaseItemPrefab, _gridContentTransform);
                purchaseItem.Initialize(item.IconName, item.Count);
            }
        }
    }
}
