using Zenject;

namespace UI.Windows.PurchaseOffer
{
    public class PurchaseOfferWindowController : IInitializable
    {
        private PurchaseOfferWindowView _purchaseOfferWindowView;
        private PurchaseOfferWindowModel _purchaseOfferWindowModel;

        [Inject]
        public PurchaseOfferWindowController(PurchaseOfferWindowView purchaseOfferWindowView,
            PurchaseOfferWindowModel purchaseOfferWindowModel)
        {
            _purchaseOfferWindowView = purchaseOfferWindowView;
            _purchaseOfferWindowModel = purchaseOfferWindowModel;
        }
        
        public void Initialize()
        {
            _purchaseOfferWindowView.UpdateView(_purchaseOfferWindowModel.CurrentOffer.Offer);
        }
    }
}