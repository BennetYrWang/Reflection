using System;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

namespace Interaction
{
    public class DialogueBox : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textMeshProUGUI;
        private HoverableUIElement _hoverableUIElement;
        public TextMeshProUGUI TextMeshProUGUI => textMeshProUGUI;
        [SerializeField] private Image boxBackground;
        private RectTransform _rectTransform;

        public void Initialize(Rect boxRect, string text)
        {
            _rectTransform.anchorMin = boxRect.min;
            _rectTransform.anchorMax = boxRect.max;

            textMeshProUGUI.text = text;
        }

        private void Update()
        {
            
        }

        private void HandleControllerInput()
        {
            
        }
    }
}