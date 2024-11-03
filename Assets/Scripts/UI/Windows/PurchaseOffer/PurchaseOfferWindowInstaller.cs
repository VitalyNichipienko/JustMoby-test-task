using UnityEngine;
using Zenject;

namespace UI.Windows.PurchaseOffer
{
    public class PurchaseOfferWindowInstaller : MonoInstaller
    {
        [SerializeField] private PurchaseOfferWindowView _purchaseOfferWindowView;
        
        public override void InstallBindings()
        {
            BindPurchaseOfferWindowView();
            BindPurchaseOfferWindowModel();
            BindPurchaseOfferWindowController();
        }

        private void BindPurchaseOfferWindowView()
        {
            Container.Bind<PurchaseOfferWindowView>().FromInstance(_purchaseOfferWindowView).AsSingle().NonLazy();
        }

        private void BindPurchaseOfferWindowModel()
        {
            Container.Bind<PurchaseOfferWindowModel>().AsSingle().NonLazy();
        }

        private void BindPurchaseOfferWindowController()
        {
            Container.Bind<IInitializable>().To<PurchaseOfferWindowController>().AsSingle().NonLazy();
        }
    }
}