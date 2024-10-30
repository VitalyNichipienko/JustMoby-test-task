using Core.Infrastructure.UiManagement;
using Zenject;

namespace UI.Windows.Game
{
    public class GameWindowModel
    {
        private UiManager _uiManager;

        [Inject]
        public GameWindowModel(UiManager uiManager)
        {
            _uiManager = uiManager;
        }
    }
}