using System.Collections.Generic;
using Core.Infrastructure.StateMachine;
using Core.Infrastructure.States;
using Zenject;

namespace UI.Windows.Menu
{
    public class MenuWindowModel
    {
        private GameStateMachine<IState> _gameStateMachine;
        private MenuWindowView _menuWindowView;

        [Inject]
        public MenuWindowModel(GameStateMachine<IState> gameStateMachine, MenuWindowView menuWindowView)
        {
            _gameStateMachine = gameStateMachine;
            _menuWindowView = menuWindowView;
        }
        
        public void StartNewGame()
        {
            _gameStateMachine.Enter<GameState>();
        }
    }
}
