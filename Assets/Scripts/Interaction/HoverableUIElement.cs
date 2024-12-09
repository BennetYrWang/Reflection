using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Interaction
{
    public class HoverableUIElement : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public UnityEvent<PointerEventData> OnHoverEnter;
        public UnityEvent<PointerEventData> OnHoverExit;
        public UnityEvent OnHoverStay;

        public bool Hovering => _pointerStay;
        private bool _pointerStay = false;

        private void Update()
        {
            if (_pointerStay)
                OnHoverStay?.Invoke();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            OnHoverEnter?.Invoke(eventData);
            _pointerStay = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            OnHoverExit?.Invoke(eventData);
            _pointerStay = false;
        }
    }
}
