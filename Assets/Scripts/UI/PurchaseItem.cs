using Core.Infrastructure.Services.ResourceLoader;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class PurchaseItem : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _countText;

        private ResourceLoaderService _resourceLoaderService;

        [Inject]
        private void Construct(ResourceLoaderService resourceLoaderService)
        {
            _resourceLoaderService = resourceLoaderService;
        }

        public void Initialize(string spriteName, int itemCount)
        {
            _countText.text = itemCount.ToString();

            var offerSprite = _resourceLoaderService.LoadSprite(spriteName);

            if (offerSprite != null)
            {
                _icon.sprite = offerSprite;
            }
            else
            {
                Debug.LogError($"[{typeof(PurchaseItem)}] Failed to load sprite for offer: {spriteName}");
            }
        }
    }
}