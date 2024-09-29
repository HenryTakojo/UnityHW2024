using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace EnhancedUI.EnhancedScroller
{
    public class ScrollRectDragState : ScrollRect, IPointerDownHandler, IPointerUpHandler
    {
        public bool IsDrag { get; private set; }

        public override void OnBeginDrag(PointerEventData eventData)
        {
            base.OnBeginDrag(eventData);
            IsDrag = true;
        }

        public override void OnEndDrag(PointerEventData eventData)
        {
            base.OnEndDrag(eventData);
            IsDrag = false;
        }

        private bool _isPointerDown;
        private Vector2 _pointerDownPos;
        public Action OnClick = null;

        void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
        {
            _isPointerDown = true;
            _pointerDownPos = eventData.position;
        }

        void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
        {
            if (_isPointerDown)
            {
                float dis = Vector2.SqrMagnitude(_pointerDownPos - eventData.position);
                float maxDis = (Screen.width * 0.01f) * (Screen.width * 0.01f);
                if (dis < maxDis)
                {
                    OnClick?.Invoke();
                }
            }
            _isPointerDown = false;
        }
    }

}
