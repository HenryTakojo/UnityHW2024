using EnhancedUI.EnhancedScroller;
using System;
using UnityEngine;
using UnityEngine.UI;

public class GridSampleView : EnhancedScrollerView
{
    [SerializeField] private Text Text_info = null;
    [SerializeField] private Image Img_Active = null;
    [SerializeField] private Button Btn_SwitchActive = null;

    private GridSampleData _data = null;

    public override void SetData(EnhancedScrollerData data, Action<int> OnClickCB = null)
    {
        _data = data as GridSampleData;
        _onClickCB = OnClickCB;
        if (Btn_SwitchActive != null)
        {
            Btn_SwitchActive.onClick.RemoveAllListeners();
            Btn_SwitchActive.onClick.AddListener(BtnClick_SwitchActive);
        }
        if (_data == null) return;
        if (Text_info != null) Text_info.text = _data.nameInfo;
        if (Img_Active != null) Img_Active.enabled = _data.isSelect;
    }

    public override void RefreshCellView()
    {
        if (_data == null) return;
        if (Img_Active != null) Img_Active.enabled = _data.isSelect;
    }

    public void BtnClick_SwitchActive()
    {
        if (_data == null) return;
        if (_onClickCB != null) _onClickCB.Invoke(_data.dataIndex);
    }
}
