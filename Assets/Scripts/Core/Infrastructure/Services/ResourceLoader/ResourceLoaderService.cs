using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Core.Infrastructure.Services.ResourceLoader
{
    public class ResourceLoaderService
    {
        private const string SpritePath = "Sprites/";
        
        private readonly Dictionary<string, Object> _cache = new Dictionary<string, Object>();

        public T LoadResource<T>(string resourcePath) where T : Object
        {
            if (_cache.TryGetValue(resourcePath, out var cachedResource) && cachedResource is T resource)
            {
                return resource;
            }

            resource = Resources.Load<T>(resourcePath);

            if (resource == null)
            {
                Debug.LogError($"[{nameof(ResourceLoaderService)}] Resource not found at path: {resourcePath}");
                return null;
            }

            _cache[resourcePath] = resource;
            return resource;
        }

        public Sprite LoadSprite(string spriteName)
        {
            return LoadResource<Sprite>($"{SpritePath}{spriteName}");
        }
    }
}