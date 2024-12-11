using System;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    public class HoverableCollider2DManager : MonoBehaviour
    {
        public static HoverableCollider2DManager Instance { get; private set; }
        
        private Dictionary<HoverableCollider2D, HoverableColliderInfo> _hoverableColliders = new();
        private HashSet<HoverableCollider2D> _hovering = new();
        private HashSet<HoverableCollider2D> _detected = new();
        private List<HoverableCollider2D> _exitingCollider = new();

        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            _detected.Clear();
            _exitingCollider.Clear();
            
            var hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider == null)
                    continue;
                
                var hoverable = hit.collider.GetComponent<HoverableCollider2D>();
                if (hoverable == null)
                    continue;
                
                _detected.Add(hoverable);
                var info = _hoverableColliders[hoverable];
                
                if (_hovering.Add(hoverable))
                    info.OnHoverBegin?.Invoke();
                else
                    info.OnHoverStay?.Invoke();
            }
            
            foreach (var hoverableCollider in _hovering)
            {
                if (_detected.Contains(hoverableCollider))
                    continue;
                _exitingCollider.Add(hoverableCollider);
            }

            foreach (var exitingCollider in _exitingCollider)
            {
                _hovering.Remove(exitingCollider);
                _hoverableColliders.TryGetValue(exitingCollider, out var info);
                info.OnHoverExit?.Invoke();
            }
        }

        public void RegisterHoverableCollider(HoverableCollider2D hoverableCollider2D, Action onHoverBegin = null,
            Action onHoverStays = null, Action onHoverExit = null)
        {
            _hoverableColliders.Add(hoverableCollider2D, new HoverableColliderInfo()
            {
                OnHoverBegin = onHoverBegin,
                OnHoverStay = onHoverStays,
                OnHoverExit = onHoverExit
            });
        }

        public void UnRegisterHoverableCollider(HoverableCollider2D hoverableCollider2D)
        {
            _hoverableColliders.Remove(hoverableCollider2D);
            _hovering.Remove(hoverableCollider2D);
        }

        private class HoverableColliderInfo
        {
            public bool Hovering;
            public Vector2 HitPoint;
            public Action OnHoverBegin;
            public Action OnHoverStay;
            public Action OnHoverExit;
        }
    }
}