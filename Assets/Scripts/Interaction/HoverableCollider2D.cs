using System;
using UnityEngine;
using UnityEngine.Events;

namespace Interaction
{
    [RequireComponent(typeof(Collider2D))]
    public class HoverableCollider2D : MonoBehaviour
    {
        public event Action OnHoverBegin, OnHoverStay, OnHoverExit;
        private void Start()
        {
            HoverableCollider2DManager.Instance.RegisterHoverableCollider(this,OnHoverBegin,OnHoverStay,OnHoverExit);
        }
        private void OnHoverBeginHandler() => OnHoverBegin?.Invoke();
        private void OnHoverStayHandler() => OnHoverStay?.Invoke();
        private void OnHoverExitHandler() => OnHoverExit?.Invoke();

        private void OnDestroy()
        {
            HoverableCollider2DManager.Instance.UnRegisterHoverableCollider(this);
        }
    }
}