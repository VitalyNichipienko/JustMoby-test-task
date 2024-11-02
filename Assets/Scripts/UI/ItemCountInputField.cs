using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ItemCountInputField : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputField;

        public event Action<int> OnValueChanged;

        private int _minValue = 3;
        private int _maxValue = 6;

        private void Awake()
        {
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
                _inputField.text = value.ToString();

                OnValueChanged?.Invoke(value);
            }
            else
            {
                Debug.LogError(
                    $"Invalid input: '{input}'. Please enter a valid integer between {_minValue} and {_maxValue}.");
            }
        }
    }
}