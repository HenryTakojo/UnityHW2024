using EnhancedUI.EnhancedScroller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSampleData : EnhancedScrollerData
{
    public string nameInfo;
    public bool isSelect = false;
    public GridSampleData(int dataIndex) : base(dataIndex) {}
}
