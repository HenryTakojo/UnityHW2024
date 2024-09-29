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
    /// <summary>用以使用水平佈局動態更新CellView中物件</summary>
    public class ChartScroller : MonoBehaviour
    {
        #region 公開屬性

        /// <summary>Scroller滑動的方向，目前只有水平滑動</summary>
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

        public float spacing; //CellView間距，從首個Cell後開始計算

        public RectOffset padding; //Cell與containter上下左右距離

        public IChartScrollerDelegate Delegate { get { return _delegate; } set { _delegate = value; _reloadData = true; } }

        #endregion 公開屬性
        #region 非公開屬性

        private RectTransform _scrollRectTransform;

        /// <summary>存放目前正在展示的CellView List</summary>
        private SmallList<EnhancedScrollerCellView> _activeCellViews = new SmallList<EnhancedScrollerCellView>();

        private ScrollRect _scrollRect;
        private ScrollRectDragState _scrollRectDragState; //繼承ScrollRect的擴展方法，使用"ScrollRectDragState"組件取代"ScrollRect"組件

        /// <summary>包含所有Cell</summary>
        private RectTransform _container;

        /// <summary>掌控Cell在Container內的排列</summary>
        private HorizontalOrVerticalLayoutGroup _layoutGroup;

        /// <summary>執行圖表內容更新委派</summary>
        private IChartScrollerDelegate _delegate;

        /// <summary>初始化或重塑圖表時更新全Data</summary>
        private bool _reloadData = false;

        //存取_scrollRect的方框大小與位置

        #endregion 非公開屬性

        private void Awake()
        {
            _scrollRect = this.GetComponent<ScrollRect>();
            _scrollRectDragState = _scrollRect as ScrollRectDragState;
            _scrollRectTransform = _scrollRect.GetComponent<RectTransform>();

            //製作"Container"物件
            GameObject go = new GameObject("Container", typeof(RectTransform));
            go.transform.SetParent(_scrollRectTransform);
            if (scrollDirection == ScrollDirectionEnum.Vertical)
            {
                Debug.LogError("滑動方向輸入錯誤");
                return;
                go.AddComponent<VerticalLayoutGroup>();
            }
            else
                go.AddComponent<HorizontalLayoutGroup>();
            _container = go.GetComponent<RectTransform>();

            //設定Container的anchor和pivot
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

        /// <summary>等於在LateUpdate檢測ScrollRect數值的改變</summary>
        /// <param name="val"></param>
        private void _ScrollRect_OnValueChanged(Vector2 val)
        {
            //更新ActiveCell位置
            //依照"視區"更新CellView位置 = activeCellView[索引]
            //或依照"視區"更新ScrollRect位置

            //Snap功能是否打開
        }

        void Update()
        {
            //確認Delegate的函式是否觸發 = 更新CellView內的內容

            if (_reloadData)
            {
                //若有Delegate，Awake後更新圖表
                //ReloadData();
            }
        }

        /// <summary>Awake後更新圖表</summary>
        void ReloadData()
        {

        }


    }

    /// <summary>Controller繼承的介面，控制CellView為Active時顯示對應Data的資料</summary>
    public interface IChartScrollerDelegate
    {

    }
}