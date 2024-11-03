using Zenject;

namespace UI.Windows.PurchaseOffer
{
    public class PurchaseOfferWindowController : IInitializable
    {
        private readonly PurchaseOfferWindowView _purchaseOfferWindowView;
        private readonly PurchaseOfferWindowModel _purchaseOfferWindowModel;

        [Inject]
        public PurchaseOfferWindowController(PurchaseOfferWindowView purchaseOfferWindowView,
            PurchaseOfferWindowModel purchaseOfferWindowModel)
        {
            _purchaseOfferWindowView = purchaseOfferWindowView;
            _purchaseOfferWindowModel = purchaseOfferWindowModel;
        }
        
        public void Initialize()
        {
            _purchaseOfferWindowView.OnWindowShow += HandlePurchaseOfferWindowShow;
            _purchaseOfferWindowView.PurchaseButton.Button.onClick.AddListener(_purchaseOfferWindowModel.BuyOffer);
        }

        ~PurchaseOfferWindowController()
        {
            _purchaseOfferWindowView.OnWindowShow -= HandlePurchaseOfferWindowShow;
            _purchaseOfferWindowView.PurchaseButton.Button.onClick.RemoveListener(_purchaseOfferWindowModel.BuyOffer);
        }
        
        private void HandlePurchaseOfferWindowShow()
        {
            _purchaseOfferWindowModel.UpdateOffer();
            _purchaseOfferWindowView.UpdateView(_purchaseOfferWindowModel.CurrentOffer.Offer);
        }
    }
}