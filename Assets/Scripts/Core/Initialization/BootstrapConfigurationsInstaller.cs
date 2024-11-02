using Core.Data;
using Core.Infrastructure.UiManagement;
using UI.Configurations;
using UnityEngine;
using Zenject;

namespace Core.Initialization
{
    [CreateAssetMenu(menuName = "Installers/Create bootstrap configs installer", fileName = "BootstrapConfigsInstaller")]
    public class BootstrapConfigurationsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private WindowsPrefabsContainer windowsPrefabsContainer;
        [SerializeField] private UiConfiguration uiConfiguration;
        [SerializeField] private OffersContainer offersContainer;
        
        public override void InstallBindings()
        {
            BindWindowsPrefabsContainer();
            BindUiConfiguration();
            BindOffersContainer();
        }

        private void BindWindowsPrefabsContainer() => 
            Container.Bind<WindowsPrefabsContainer>().FromInstance(windowsPrefabsContainer).AsSingle().NonLazy();

        private void BindUiConfiguration() =>
            Container.Bind<UiConfiguration>().FromInstance(uiConfiguration).AsSingle().NonLazy();

        private void BindOffersContainer() => 
            Container.Bind<OffersContainer>().FromInstance(offersContainer).AsSingle().NonLazy();
    }
}
