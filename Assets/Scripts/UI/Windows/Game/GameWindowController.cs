using Core.Data;
using Core.Infrastructure.UiManagement;
using UI.Configurations;
using UI.Windows.PurchaseOffer;
using Zenject;

namespace UI.Windows.Game
{
    public class GameWindowController : IInitializable
    {
        private GameWindowView _gameWindowView;
        private GameWindowModel _gameWindowModel;
        private UiConfiguration _uiConfiguration;
        private UiManager _uiManager;
        private GameData _gameData;

        [Inject]
        public GameWindowController(GameWindowView gameWindowView, GameWindowModel gameWindowModel,
            UiConfiguration uiConfiguration, UiManager uiManager, GameData gameData)
        {
            _gameWindowView = gameWindowView;
            _gameWindowModel = gameWindowModel;
            _uiConfiguration = uiConfiguration;
            _uiManager = uiManager;
            _gameData = gameData;
        }

        public void Initialize()
        {
            _gameWindowView.ItemCountInputField.OnValueChanged += HandleValueChanged;
            _gameWindowView.ReceiveOfferButton.onClick.AddListener(HandleReceiveOfferButtonClick);
        }

        private void HandleReceiveOfferButtonClick()
        {
            _uiManager.ShowWindow<PurchaseOfferWindowView>();
        }

        private void HandleValueChanged(int value)
        {
            _gameData.ItemCountInOffer = value;
        }
    }
}