using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    public class PurchaseButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _discountPriceText;
        [SerializeField] private TextMeshProUGUI _regularPriceText;
        [SerializeField] private TextMeshProUGUI _discountPercentageText;

        public void Initialize(string discountPrice, string regularPrice, string discountPercentage)
        {
            _discountPriceText.text = discountPrice;
            _regularPriceText.text = regularPrice;
            _discountPercentageText.text = discountPercentage;
        }
    }
}