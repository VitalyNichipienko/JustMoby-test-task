using System;
using System.Collections.Generic;
using Core.Data.Game;
using Core.Infrastructure;
using Core.Infrastructure.SceneLoad;
using Core.Infrastructure.Services.CoroutineRunner;
using Core.Infrastructure.Services.ResourceLoader;
using Core.Infrastructure.StateMachine;
using Core.Infrastructure.States;
using Core.Infrastructure.UiManagement;
using UnityEngine;
using Zenject;

namespace Core.Initialization
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private CoroutineRunner _coroutineRunner;
        
        public override void InstallBindings()
        {
            BindCoroutineRunner();
            BindCommonFactory();
            BindUiManager();
            BindSceneLoader();
            BindGameStateMachine();
            BindGameData();
            BindResourceLoaderService();
        }

        private void BindResourceLoaderService()
        {
            Container.Bind<ResourceLoaderService>().AsSingle().NonLazy();
        }

        private void BindGameData()
        {
            Container.Bind<GameData>().FromNew().AsSingle().NonLazy();
        }

        private void BindCommonFactory()
        {
            Container.Bind<CommonFactory>().FromInstance(new CommonFactory(Container)).AsSingle();
        }

        private void BindUiManager()
        {
            Container.Bind<UiManager>().AsSingle().NonLazy();
        }

        private void BindCoroutineRunner()
        {
            Container.Bind<ICoroutineRunner>().FromInstance(_coroutineRunner).AsSingle();
        }

        private void BindSceneLoader()
        {
            Container.Bind<SceneLoader>().AsSingle().NonLazy();
        }

        private void BindGameStateMachine()
        {
            var stateMachine = new GameStateMachine<IState>();
            Container.Bind<GameStateMachine<IState>>().FromInstance(stateMachine).AsSingle();
  
            var states = new Dictionary<Type, IState>
            {
                [typeof(BootstrapState)] = Container.Instantiate<BootstrapState>(),
                [typeof(LoadSceneState)] = Container.Instantiate<LoadSceneState>(),
                [typeof(GameState)] = Container.Instantiate<GameState>()
            };
        
            stateMachine.FillStateDictionary(states);
        }
    }
}
