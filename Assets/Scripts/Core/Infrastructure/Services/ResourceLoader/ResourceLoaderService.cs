using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Core.Infrastructure.Services.ResourceLoader
{
    public class ResourceLoaderService
    {
        private const string SpritePath = "Sprites/";
        
        private readonly Dictionary<string, Object> _cache = new Dictionary<string, Object>();

        public async UniTask<T> LoadResourceAsync<T>(string resourcePath) where T : Object
        {
            if (_cache.TryGetValue(resourcePath, out var cachedResource) && cachedResource is T resource)
            {
                return resource;
            }

            await UniTask.SwitchToMainThread();
            
            resource = Resources.Load<T>(resourcePath);

            if (resource == null)
            {
                Debug.LogError($"[{nameof(ResourceLoaderService)}] Resource not found at path: {resourcePath}");
                return null;
            }

            _cache[resourcePath] = resource;
            return resource;
        }

        public async UniTask<Sprite> LoadSpriteAsync(string spriteName)
        {
            return await LoadResourceAsync<Sprite>($"{SpritePath}{spriteName}");
        }
    }
}