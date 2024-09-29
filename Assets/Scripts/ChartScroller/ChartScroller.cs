using EnhancedUI;
using EnhancedUI.EnhancedScroller;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XCharts.Runtime;

namespace ScrollerExtention
{
    /// <summary>�ΥH�ϥΤ����G���ʺA��sCellView������</summary>
    public class ChartScroller : MonoBehaviour
    {
        #region ���}�ݩ�

        /// <summary>Scroller�ưʪ���V�A�ثe�u�������ư�</summary>
        public enum ScrollDirectionEnum
        {
            Vertical,
            Horizontal
        }

        /// <summary></summary>
        public ScrollDirectionEnum scrollDirection;

        public bool IsDrag
        {
            get
            {
                return _scrollRectDragState != null ? _scrollRectDragState.IsDrag : false;
            }
        }

        public float spacing; //CellView���Z�A�q����Cell��}�l�p��

        public RectOffset padding; //Cell�Pcontainter�W�U���k�Z��

        public IChartScrollerDelegate Delegate { get { return _delegate; } set { _delegate = value; _reloadData = true; } }

        #endregion ���}�ݩ�
        #region �D���}�ݩ�

        private RectTransform _scrollRectTransform;

        /// <summary>�s��ثe���b�i�ܪ�CellView List</summary>
        private SmallList<EnhancedScrollerCellView> _activeCellViews = new SmallList<EnhancedScrollerCellView>();

        private ScrollRect _scrollRect;
        private ScrollRectDragState _scrollRectDragState; //�~��ScrollRect���X�i��k�A�ϥ�"ScrollRectDragState"�ե���N"ScrollRect"�ե�

        /// <summary>�]�t�Ҧ�Cell</summary>
        private RectTransform _container;

        /// <summary>�x��Cell�bContainer�����ƦC</summary>
        private HorizontalOrVerticalLayoutGroup _layoutGroup;

        /// <summary>����Ϫ��e��s�e��</summary>
        private IChartScrollerDelegate _delegate;

        /// <summary>��l�Ʃέ���Ϫ�ɧ�s��Data</summary>
        private bool _reloadData = false;

        //�s��_scrollRect����ؤj�p�P��m

        #endregion �D���}�ݩ�

        private void Awake()
        {
            _scrollRect = this.GetComponent<ScrollRect>();
            _scrollRectDragState = _scrollRect as ScrollRectDragState;
            _scrollRectTransform = _scrollRect.GetComponent<RectTransform>();

            //�s�@"Container"����
            GameObject go = new GameObject("Container", typeof(RectTransform));
            go.transform.SetParent(_scrollRectTransform);
            if (scrollDirection == ScrollDirectionEnum.Vertical)
            {
                Debug.LogError("�ưʤ�V��J���~");
                return;
                go.AddComponent<VerticalLayoutGroup>();
            }
            else
                go.AddComponent<HorizontalLayoutGroup>();
            _container = go.GetComponent<RectTransform>();

            //�]�wContainer��anchor�Mpivot
            if (scrollDirection == ScrollDirectionEnum.Vertical)
            {
                _container.anchorMin = new Vector2(0, 1);
                _container.anchorMax = Vector2.one;
                _container.pivot = new Vector2(0.5f, 1f);
            }
            else
            {
                _container.anchorMin = Vector2.zero;
                _container.anchorMax = new Vector2(0, 1f);
                _container.pivot = new Vector2(0, 0.5f);
            }
            _container.offsetMax = Vector2.zero;
            _container.offsetMin = Vector2.zero;
            _container.localPosition = Vector3.zero;
            _container.localRotation = Quaternion.identity;
            _container.localScale = Vector3.one;

            _scrollRect.content = _container;

            _layoutGroup = _container.GetComponent<HorizontalOrVerticalLayoutGroup>();
            _layoutGroup.spacing = spacing;
            _layoutGroup.padding = padding;
            _layoutGroup.childAlignment = TextAnchor.UpperLeft;
            _layoutGroup.childForceExpandHeight = true;
            _layoutGroup.childForceExpandWidth = true;

            _scrollRect.horizontal = scrollDirection == ScrollDirectionEnum.Horizontal;
            _scrollRect.vertical = scrollDirection == ScrollDirectionEnum.Vertical;
        }

        void Start()
        {
            ReloadData();
        }

        void OnEnable()
        {
            _scrollRect.onValueChanged.AddListener(_ScrollRect_OnValueChanged);
        }

        void OnDisable()
        {
            _scrollRect.onValueChanged.RemoveListener(_ScrollRect_OnValueChanged);
        }

        /// <summary>����bLateUpdate�˴�ScrollRect�ƭȪ�����</summary>
        /// <param name="val"></param>
        private void _ScrollRect_OnValueChanged(Vector2 val)
        {
            //��sActiveCell��m
            //�̷�"����"��sCellView��m = activeCellView[����]
            //�Ψ̷�"����"��sScrollRect��m

            //Snap�\��O�_���}
        }

        void Update()
        {
            //�T�{Delegate���禡�O�_Ĳ�o = ��sCellView�������e

            if (_reloadData)
            {
                //�Y��Delegate�AAwake���s�Ϫ�
                //ReloadData();
            }
        }

        /// <summary>Awake���s�Ϫ�</summary>
        void ReloadData()
        {

        }


    }

    /// <summary>Controller�~�Ӫ������A����CellView��Active����ܹ���Data�����</summary>
    public interface IChartScrollerDelegate
    {

    }
}