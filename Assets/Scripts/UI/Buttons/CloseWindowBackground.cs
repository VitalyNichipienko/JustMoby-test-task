using Core.Infrastructure.UiManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace UI.Buttons
{
    public class CloseWindowBackground : MonoBehaviour, IPointerClickHandler
    {
        private UiManager _uiManager;

        [Inject]
        private void Construct(UiManager uiManager)
        {
            _uiManager = uiManager;
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            _uiManager.CloseCurrentWindow();
        }
    }
}
