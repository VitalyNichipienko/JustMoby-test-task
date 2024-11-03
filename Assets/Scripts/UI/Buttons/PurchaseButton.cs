using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    public class PurchaseButton : MonoBehaviour
    {
        [field: SerializeField] public Button Button { get; private set; }

        [SerializeField] private TextMeshProUGUI _discountPriceText;
        [SerializeField] private TextMeshProUGUI _regularPriceText;
        [SerializeField] private TextMeshProUGUI _discountPercentageText;
        [SerializeField] private Image _discountImage;
        [SerializeField] private TextMeshProUGUI _basePriceText;

        public void Initialize(int discountPrice, int regularPrice, int discountPercentage, bool isDiscountActive)
        {
            if (isDiscountActive)
            {
                SetActiveDiscountUI(discountPrice, regularPrice, discountPercentage);
            }
            else
            {
                SetActiveBasePriceUI(regularPrice);
            }
        }

        private void SetActiveDiscountUI(int discountPrice, int regularPrice, int discountPercentage)
        {
            _discountPriceText.text = discountPrice.ToString();
            _regularPriceText.text = $"<s>{regularPrice.ToString()}</s>";
            _discountPercentageText.text = $"-{discountPercentage.ToString()}%";

            SetUIElementsActive(true);
        }

        private void SetActiveBasePriceUI(int regularPrice)
        {
            _basePriceText.text = regularPrice.ToString();

            SetUIElementsActive(false);
        }

        private void SetUIElementsActive(bool isActive)
        {
            _discountPriceText.gameObject.SetActive(isActive);
            _regularPriceText.gameObject.SetActive(isActive);
            _discountPercentageText.gameObject.SetActive(isActive);
            _discountImage.gameObject.SetActive(isActive);

            _basePriceText.gameObject.SetActive(!isActive);
        }
    }
}