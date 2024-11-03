using System;
using Core.Data.Game;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI.Elems
{
    public class ItemCountInputField : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputField;

        public event Action<int> OnValueChanged;

        private int _minValue;
        private int _maxValue;

        [Inject]
        private void Construct(GameData gameData)
        {
            _minValue = gameData.MinItemCount;
            _maxValue = gameData.MaxItemCount;
        }

        private void Awake()
        {
            HandleValueChanged(_minValue.ToString());
            _inputField.onValueChanged.AddListener(HandleValueChanged);
        }

        private void OnDestroy()
        {
            _inputField.onValueChanged.RemoveListener(HandleValueChanged);
        }

        private void HandleValueChanged(string input)
        {
            if (int.TryParse(input, out int value))
            {
                value = Mathf.Clamp(value, _minValue, _maxValue);
            }
            else
            {
                value = _minValue;
            }
            
            _inputField.text = value.ToString();
            OnValueChanged?.Invoke(value);
        }
    }
}