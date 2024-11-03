using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows
{
    public class Window : MonoBehaviour
    {
        [SerializeField] protected Canvas Root;
        [SerializeField] protected GraphicRaycaster Raycaster;
        private int _sortingOrder;

        public event Action OnWindowShow;
        public event Action OnWindowHide;

        public virtual void Show()
        {
            Raycaster.enabled = true;
            Root.enabled = true;
            
            OnWindowShow?.Invoke();
        }

        public virtual void Hide()
        {
            Raycaster.enabled = false;
            Root.enabled = false;
            
            OnWindowHide?.Invoke();
        }

        public void SetSortingOrder(int order)
        {
            _sortingOrder = order;
            Root.sortingOrder = order; 
        }

        public int GetSortingOrder()
        {
            return _sortingOrder; 
        }
    }
}
