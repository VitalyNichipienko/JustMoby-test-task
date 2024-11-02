using System;
using UnityEngine;

namespace Core.Data
{
    [Serializable]
    public class ItemData
    {
        [field: SerializeField] public int Count { get; private set; }
        [field: SerializeField] public string IconName { get; private set; }
    }
}