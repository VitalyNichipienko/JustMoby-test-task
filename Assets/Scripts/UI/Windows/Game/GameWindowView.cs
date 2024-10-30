using UI.Configurations;
using Zenject;

namespace UI.Windows.Game
{
    public class GameWindowView : Window
    {
        private UiConfiguration _uiConfiguration;
        
        [Inject]
        private void Construct(UiConfiguration uiConfiguration)
        {
            _uiConfiguration = uiConfiguration;
        }
    }
}