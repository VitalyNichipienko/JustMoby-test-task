using System;
using System.Collections.Generic;
using UI.Windows;
using UnityEngine;
using Zenject;

namespace Core.Infrastructure.UiManagement
{
    public class WindowsPool : MonoBehaviour
    {
        [SerializeField] private Canvas _root;

        private readonly Dictionary<Type, Window> _cachedWindows = new Dictionary<Type, Window>();
        
        private WindowsPrefabsContainer _windowsPrefabsContainer;
        private CommonFactory _commonFactory;

        [Inject]
        public void Construct(CommonFactory commonFactory, WindowsPrefabsContainer prefabsContainer)
        {
            _commonFactory = commonFactory;
            _windowsPrefabsContainer = prefabsContainer;
        }

        public T Get<T>() where T : Window
        {
            return (T) Get(typeof(T));
        }
        
        public Window Get(Type type)
        {
            if (_cachedWindows.TryGetValue(type, out Window windowBase))
                return windowBase;

            if (_windowsPrefabsContainer.TryGet(type, out Window prefab))
            {
                var instance =  _commonFactory.Instantiate(prefab, _root.transform);
                _cachedWindows.Add(type, instance);
                return instance;
            }

            throw new Exception("Cannot find window prefab");
        }
        
        public void Destroy<T>() where T : Window
        {
            Destroy(typeof(T));
        }
        
        private void Destroy(Type type)
        {
            if (_cachedWindows.TryGetValue(type, out Window windowBase))
            {
                Destroy(windowBase.gameObject);
                _cachedWindows.Remove(type);
            }
        }
    }
}