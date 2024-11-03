using Core.Data;
using Core.Data.Game;
using Zenject;

namespace UI.Windows.Game
{
    public class GameWindowController : IInitializable
    {
        private readonly GameWindowView _gameWindowView;
        private readonly GameWindowModel _gameWindowModel;
        
        [Inject]
        public GameWindowController(GameWindowView gameWindowView, GameWindowModel gameWindowModel,
            GameData gameData)
        {
            _gameWindowView = gameWindowView;
            _gameWindowModel = gameWindowModel;
        }

        public void Initialize()
        {
            _gameWindowView.ItemCountInputField.OnValueChanged += _gameWindowModel.HandleValueChanged;
            _gameWindowView.ReceiveOfferButton.onClick.AddListener(_gameWindowModel.HandleReceiveOfferButtonClick);
        }

        ~GameWindowController()
        {
            _gameWindowView.ItemCountInputField.OnValueChanged -= _gameWindowModel.HandleValueChanged;
            _gameWindowView.ReceiveOfferButton.onClick.RemoveListener(_gameWindowModel.HandleReceiveOfferButtonClick);
        }
    }
}