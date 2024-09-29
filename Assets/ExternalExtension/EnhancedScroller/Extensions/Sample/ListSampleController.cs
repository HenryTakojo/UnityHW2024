using EnhancedUI.EnhancedScroller;
using System.Collections.Generic;

public class ListSampleController : EnhancedScrollerController
{
    private List<ListSampleData> datas = new List<ListSampleData>();
    private int selectIndex = -1;

    protected override void OnInit()
    {
        for (int i = 0; i < 100; i++)
        {
            ListSampleData newData = new ListSampleData(i)
            {
                nameInfo = $"ListItem {i}",
            };
            datas.Add(newData);
        }
    }

    public override int GetNumberOfCells(EnhancedScroller scroller)
	{
		return datas.Count;
	}

	public override float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
	{
		return viewTemplates[0].size;
	}

	public override EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
	{
        ListSampleView cellView = scroller.GetCellView(viewTemplates[0].prefab) as ListSampleView;
        cellView.SetData(datas[dataIndex], OnCLick);
        return cellView;
	}

    protected override void OnCLick(int dataIndex)
    {
        //單選
        if (dataIndex == selectIndex)
            return;
        if (selectIndex >= 0 && selectIndex < datas.Count)
            datas[selectIndex].isSelect = false;
        selectIndex = dataIndex;
        datas[selectIndex].isSelect = true;

        scroller.RefreshActiveCellViews();
    }
}
