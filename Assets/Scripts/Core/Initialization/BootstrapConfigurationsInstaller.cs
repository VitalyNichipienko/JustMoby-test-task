using Core.Data.Offers;
using Core.Infrastructure.UiManagement;
using UI.Configurations;
using UnityEngine;
using Zenject;

namespace Core.Initialization
{
    [CreateAssetMenu(menuName = "Installers/Create bootstrap configs installer", fileName = "BootstrapConfigsInstaller")]
    public class BootstrapConfigurationsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private WindowsPrefabsContainer _windowsPrefabsContainer;
        [SerializeField] private OffersContainer _offersContainer;
        [SerializeField] private OfferConfiguration _offerConfiguration;
        
        public override void InstallBindings()
        {
            BindWindowsPrefabsContainer();
            BindOffersContainer();
            BindOfferConfiguration();
        }

        private void BindOfferConfiguration()
        {
            Container.Bind<OfferConfiguration>().FromInstance(_offerConfiguration).AsSingle().NonLazy();
        }

        private void BindWindowsPrefabsContainer()
        {
            Container.Bind<WindowsPrefabsContainer>().FromInstance(_windowsPrefabsContainer).AsSingle().NonLazy();
        }

        private void BindOffersContainer()
        {
            Container.Bind<OffersContainer>().FromInstance(_offersContainer).AsSingle().NonLazy();
        }
    }
}
