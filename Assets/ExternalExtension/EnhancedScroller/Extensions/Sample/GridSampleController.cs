using System.Collections.Generic;
using UnityEngine;
using EnhancedUI.EnhancedScroller;

public class GridSampleController : EnhancedScrollerController
{
    private List<GridSampleData> datas = new List<GridSampleData>();
	private int _groupChildCount = 0;
    private List<int> selectIndexs = new List<int>();

    protected override void OnInit()
	{
        _groupChildCount = viewTemplates[0].childCount;

        for (int i = 0; i < 100; i++)
        {
            GridSampleData newData = new GridSampleData(i)
            {
                nameInfo = $"GridItem {i}",
            };
            datas.Add(newData);
        }
    }

	public override int GetNumberOfCells(EnhancedScroller scroller)
	{
		return Mathf.CeilToInt((float)datas.Count / (float)_groupChildCount);
	}

	public override float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
	{
		return viewTemplates[0].size;
	}

	public override EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int groupIndex, int cellIndex)
	{
        EnhancedScrollerView_Group gridView = scroller.GetCellView(viewTemplates[0].prefab) as EnhancedScrollerView_Group;
        gridView.SetChildActive(groupIndex, datas.Count);

        int nowDataIndex = groupIndex * _groupChildCount;
        for (int i = 0; i < gridView.gridViews.Length; i++)
        {
            if((nowDataIndex + i) < datas.Count)
                gridView.gridViews[i].SetData(datas[nowDataIndex + i], OnCLick);
        }

        return gridView;
	}

    protected override void OnCLick(int dataIndex)
    {
        //多選
        if (dataIndex < 0 && dataIndex >= datas.Count)
            return;
        datas[dataIndex].isSelect = !datas[dataIndex].isSelect;
        if (datas[dataIndex].isSelect)
        {
            if (!selectIndexs.Contains(dataIndex))
                selectIndexs.Add(dataIndex);
        }
        else
        {
            if (selectIndexs.Contains(dataIndex))
                selectIndexs.Remove(dataIndex);
        }
        scroller.RefreshActiveCellViews();
    }
}
