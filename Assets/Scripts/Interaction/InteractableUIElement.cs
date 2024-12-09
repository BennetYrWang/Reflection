using System;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Interaction
{
    [RequireComponent(typeof(HoverableUIElement))]
    public class InteractableUIElement : MonoBehaviour
    {
        public UnityEvent<ReadOnlyCollection<KeyCode>> OnControllerKeyPressed;
        private void Start()
        {
            var hoverable = GetComponent<HoverableUIElement>();
            hoverable.OnHoverEnter.AddListener(RegisterControllerKeyPressed);
            hoverable.OnHoverExit.AddListener(UnregisterControllerKeyPressed);
        }

        private void OnDestroy()
        {
            var hoverable = GetComponent<HoverableUIElement>();
            hoverable.OnHoverEnter.RemoveListener(RegisterControllerKeyPressed);
            hoverable.OnHoverExit.RemoveListener(UnregisterControllerKeyPressed);
            UnregisterControllerKeyPressed(null);
        }

        private void RegisterControllerKeyPressed(PointerEventData pointerEventData)
        {
            GameManager.Instance.OnControllerKeyPressed += ControllerKeyPressedHandler;
        }

        private void UnregisterControllerKeyPressed(PointerEventData pointerEventData)
        {
            GameManager.Instance.OnControllerKeyPressed -= ControllerKeyPressedHandler;
        }

        private void ControllerKeyPressedHandler()
        {
            OnControllerKeyPressed?.Invoke(GameManager.Instance.PressedControlKey);
        }
        
    }
}