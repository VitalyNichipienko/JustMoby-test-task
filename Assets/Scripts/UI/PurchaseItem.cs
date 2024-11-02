using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PurchaseItem : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _countText;

        public void Initialize(string spriteName, int itemCount)
        {
            _countText.text = itemCount.ToString();
        }
    }
}
