using System;
using System.Collections.Generic;
using UI.Windows;
using Object = UnityEngine.Object;

namespace Core.Infrastructure.UiManagement
{
    public class UiManager
    {
        private int _currentSortingOrder;
        private WindowsPool _windowsPool;
        private readonly Dictionary<Type, Window> _createdWindows = new Dictionary<Type, Window>();
        private readonly List<Type> _windowsStack = new List<Type>();

        private WindowsPool WindowsPool
        {
            get
            {
                if (_windowsPool == null || _windowsPool.gameObject == null)
                {
                    _windowsPool = Object.FindObjectOfType<WindowsPool>();
                }

                return _windowsPool;
            }
        }
        
        public void ShowWindow<T>() where T : Window
        {
            var window = GetOrCreateWindow<T>();
            
            if (window != null)
            {
                UpdateWindowStack(window, true);
                window.Show();
            }
        }

        public void Clear()
        {
            _createdWindows.Clear();
            _windowsStack.Clear();
        }
        
        public void CloseCurrentWindow()
        {
            if (_windowsStack.Count == 0)
                return;

            var currentWindow = CurrentWindow();
            
            if (currentWindow != null)
            {
                UpdateWindowStack(currentWindow, false);
                currentWindow.Hide();
            }
        }
        
        private void HideAllWindows()
        {
            foreach (var window in _createdWindows.Values)
            {
                window.Hide();
            }
            
            _windowsStack.Clear();
        }

        private Window GetOrCreateWindow<T>() where T : Window
        {
            var windowType = typeof(T);
            
            if (_createdWindows.TryGetValue(windowType, out Window window))
            {
                return window;
            }

            window = WindowsPool.Get<T>();
            _createdWindows.Add(windowType, window);
            return window;
        }

        private Window GetWindow<T>() where T : Window
        {
            var windowType = typeof(T);
            
            if (_createdWindows.TryGetValue(windowType, out Window window))
            {
                return window;
            }

            return null;
        }
        
        private Window CurrentWindow()
        {
            if (_windowsStack.Count == 0)
                return null;
            
            var currentWindowType = _windowsStack[_windowsStack.Count - 1];
            _createdWindows.TryGetValue(currentWindowType, out Window currentWindow);
            return currentWindow;
        }

        private void UpdateWindowStack(Window window, bool active)
        {
            var windowType = window.GetType();

            _windowsStack.Remove(windowType);

            if (active)
            {
                TryChangeWindowSortingOrder(window);
                _windowsStack.Add(windowType);
            }
            else
            {
                _currentSortingOrder = CurrentWindow()?.GetSortingOrder() ?? 0;
            }
        }

        private void TryChangeWindowSortingOrder(Window window)
        {
            var currentWindowSortingOrder = CurrentWindow()?.GetSortingOrder() ?? 0;
            
            if (currentWindowSortingOrder > _currentSortingOrder)
            {
                return;
            }

            _currentSortingOrder++;
            window.SetSortingOrder(_currentSortingOrder);
        }
    }
}
