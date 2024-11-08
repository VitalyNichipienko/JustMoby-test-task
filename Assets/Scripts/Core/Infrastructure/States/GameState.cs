﻿using Core.Infrastructure.UiManagement;
using UI.Windows.Game;
using Zenject;

namespace Core.Infrastructure.States
{
    public class GameState : IState
    {
        private readonly UiManager _uiManager;
        
        [Inject]
        public GameState(UiManager uiManager)
        {
            _uiManager = uiManager;
        }

        public void Enter()
        {
            _uiManager.ShowWindow<GameWindowView>();
        }
    }
}