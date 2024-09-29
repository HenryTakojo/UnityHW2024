using UnityEngine;

//ScrollView的使用說明：
// 1. 下面的sample是企劃在製作介面時會預先建立，方便拉介面，程式製作時，請務必從Component移除
//    (ScrollViewSetting的GameObject底下，如果企劃在建立介面有換名稱請確認正確位置)
// 2. 自行建立要使用的Controller，加入以下的內容
//      using EnhancedUI;
//      using EnhancedUI.EnhancedScroller;
//      class繼承IEnhancedScrollerDelegate
//      public部分：(變數名稱可以自訂，但是方便理解上建議以下即可，然後統一YSM的名稱設定規則，頭一個字記得大寫)
//      public EnhancedScroller Scroller;
//      public ScrollViewSetting Setting;
//      void Start底下務必呼叫 Scroller.Delegate = this;  這樣delegate才會知道要怎麼處理
// 3. 建立delegate的三個function
//      public int GetNumberOfCells(EnhancedScroller scroller)
//      ↑設定cell的數量
//      public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
//      ↑設定cell的Size
//      public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
//      ↑設定cell的內容
// 4. 建立完成後，將此Controller加到ScrollViewSetting的GameObject底下，並將EnhancedScroller以及ScrollViewSetting的對應元件加上
// 5. 可以比照sample直接呼叫 Scroller.ReloadData();
//    推薦在Controller建立一個function並將Scroller.ReloadData()寫入，
//    在自己處理WndForm建立自己的Controller，並在ScrollViewSetting的GameObject底下加入WndProperty的Component，將自己定義的Contoller的名稱加入
//    如此在WndForm下自行調整呼叫reloadData(初始，重置，或資料變更等)

namespace EnhancedUI.EnhancedScroller
{
    [System.Serializable]
    public struct EnhancedScrollerViewTemplate
    {
        public EnhancedScrollerView prefab;
        public float size;
        public int childCount;
    }

    public abstract class EnhancedScrollerController : MonoBehaviour, IEnhancedScrollerDelegate
    {
        public EnhancedScroller scroller;
        public EnhancedScrollerViewTemplate[] viewTemplates;

        void Awake()
        {
            for (int i = 0; i < viewTemplates.Length; i++)
            {
                if (viewTemplates[i].prefab?.transform != null)
                {
                    viewTemplates[i].prefab.transform.localPosition = new Vector3(0, 10000, 0);
                }
            }
        }

        void Start()
        {
            OnInit();
            scroller.Delegate = this;
            scroller.ReloadData();
        }

        protected virtual void OnInit() { }
        protected virtual void OnCLick(int dataIndex) { }

        public abstract int GetNumberOfCells(EnhancedScroller scroller);
        public abstract float GetCellViewSize(EnhancedScroller scroller, int dataIndex);
        public abstract EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex);
        public void GetCellViewVisibility(EnhancedScrollerCellView cellView) { }
        public void GetCellViewRefreshIndex(int startIndex, int endIndex) { }
    }
}

