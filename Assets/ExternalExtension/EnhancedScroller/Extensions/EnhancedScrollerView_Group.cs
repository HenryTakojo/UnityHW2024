using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnhancedUI.EnhancedScroller
{
    public class EnhancedScrollerView_Group : EnhancedScrollerView
    {
        public EnhancedScrollerView[] gridViews;

        public void SetChildActive(int groupIndex, int dataMaxCount)
        {
            int nowDataIndex = groupIndex * gridViews.Length;
            for (int i = 0; i < gridViews.Length; i++)
            {
                gridViews[i].gameObject.SetActive((nowDataIndex + i) < dataMaxCount);
            }
        }

        public override void RefreshCellView()
        {
            for (int i = 0; i < gridViews.Length; i++)
            {
                gridViews[i]?.RefreshCellView();
            }
        }
    }
}
