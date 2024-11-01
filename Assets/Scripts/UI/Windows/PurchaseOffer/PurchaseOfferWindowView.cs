using TMPro;
using UI.Buttons;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows.PurchaseOffer
{
    public class PurchaseOfferWindowView : Window
    {
        [SerializeField] private TextMeshProUGUI _headerText;
        [SerializeField] private TextMeshProUGUI _descriptionText;
        [SerializeField] private Image _offerImage;
        [SerializeField] private Transform _gridContentTransform;
        [SerializeField] private PurchaseButton _purchaseButton;
        
        public void UpdateView(string header, string description, Sprite icon)
        {
            _headerText.text = header;
            _descriptionText.text = description;
            _offerImage.sprite = icon;
        }
    }
}
