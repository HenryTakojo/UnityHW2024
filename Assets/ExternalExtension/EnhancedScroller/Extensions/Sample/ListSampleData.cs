using EnhancedUI.EnhancedScroller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListSampleData : EnhancedScrollerData
{
    public string nameInfo;
    public bool isSelect = false;
    public ListSampleData(int dataIndex) : base(dataIndex) { }
}
