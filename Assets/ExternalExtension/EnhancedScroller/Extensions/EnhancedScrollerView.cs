
using System;

namespace EnhancedUI.EnhancedScroller
{
    public class EnhancedScrollerView : EnhancedScrollerCellView
    {
        protected Action<int> _onClickCB = null;
        public virtual void SetData(EnhancedScrollerData data, Action<int> OnClickCB = null) {}
    }
}
