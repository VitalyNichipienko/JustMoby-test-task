using Core.Data;
using Core.Data.Game;
using Core.Infrastructure.UiManagement;
using UI.Windows.PurchaseOffer;
using Zenject;

namespace UI.Windows.Game
{
    public class GameWindowModel
    {
        private readonly UiManager _uiManager;
        private readonly GameData _gameData;

        [Inject]
        public GameWindowModel(UiManager uiManager, GameData gameData)
        {
            _uiManager = uiManager;
            _gameData = gameData;
        }
        
        public void HandleReceiveOfferButtonClick()
        {
            _uiManager.ShowWindow<PurchaseOfferWindowView>();
        }

        public void HandleValueChanged(int value)
        {
            _gameData.ItemCountInOffer = value;
        }
    }
}