using UI.Configurations;
using Zenject;

namespace UI.Windows.Game
{
    public class GameWindowController : IInitializable
    {
        private GameWindowView _gameWindowView;
        private GameWindowModel _gameWindowModel;
        private UiConfiguration _uiConfiguration;

        [Inject]
        public GameWindowController(GameWindowView gameWindowView, GameWindowModel gameWindowModel, UiConfiguration uiConfiguration)
        {
            _gameWindowView = gameWindowView;
            _gameWindowModel = gameWindowModel;
            _uiConfiguration = uiConfiguration;
        }
        
        public void Initialize()
        {
            
        }
    }
}