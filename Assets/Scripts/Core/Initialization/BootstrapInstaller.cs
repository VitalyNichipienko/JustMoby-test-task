using System;
using System.Collections.Generic;
using Core.Infrastructure;
using Core.Infrastructure.SceneLoad;
using Core.Infrastructure.Services.CoroutineRunner;
using Core.Infrastructure.StateMachine;
using Core.Infrastructure.States;
using Core.Infrastructure.UiManagement;
using UnityEngine;
using Zenject;

namespace Core.Initialization
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private CoroutineRunner coroutineRunner;
        
        public override void InstallBindings()
        {
            BindCoroutineRunner();
            BindCommonFactory();
            BindUiManager();
            BindSceneLoader();
            BindGameStateMachine();
        }

        private void BindCommonFactory() => 
            Container.Bind<CommonFactory>().FromInstance(new CommonFactory(Container)).AsSingle();
        
        private void BindUiManager() => 
            Container.Bind<UiManager>().AsSingle().NonLazy();
        
        private void BindCoroutineRunner() => 
            Container.Bind<ICoroutineRunner>().FromInstance(coroutineRunner).AsSingle();
        
        private void BindSceneLoader() => 
            Container.Bind<SceneLoader>().AsSingle().NonLazy();

        private void BindGameStateMachine()
        {
            GameStateMachine<IState> stateMachine = new GameStateMachine<IState>();
            Container.Bind<GameStateMachine<IState>>().FromInstance(stateMachine).AsSingle();
  
            Dictionary<Type, IState> states = new Dictionary<Type, IState>
            {
                [typeof(BootstrapState)] = Container.Instantiate<BootstrapState>(),
                [typeof(LoadSceneState)] = Container.Instantiate<LoadSceneState>(),
                [typeof(GameState)] = Container.Instantiate<GameState>()
            };
        
            stateMachine.FillStateDictionary(states);
        }
    }
}
