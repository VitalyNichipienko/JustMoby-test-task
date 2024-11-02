using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows.Game
{
    public class GameWindowView : Window
    {
        [field: SerializeField] public Button ReceiveOfferButton { get; private set; }
        [field: SerializeField] public ItemCountInputField ItemCountInputField { get; private set; }
    }
}