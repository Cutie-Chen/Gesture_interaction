using UnityEngine;
using TMPro;

public class GestureFunctionDisplay : MonoBehaviour
{
    public TextMeshProUGUI displayText;

    public void Zoom()
    {
        displayText.text = "T1 缩放-放大";
    }
    public void Scale()
    {
        displayText.text = "T1 缩放-缩小";
    }
    public void SwitchSlice_up()
    {
        displayText.text = "T2 切换断层-上";
    }
    public void SwitchSlice_down()
    {
        displayText.text = "T2 切换断层-下";
    }
    public void Pan()
    {
        displayText.text = "T3 平移（上下左右）";
    }

    public void Rotate()
    {
        displayText.text = "T4 旋转（顺、逆时针）";
    }

    public void LayoutPanels1()
    {
        displayText.text = "T5 布局-1";
    }
    public void LayoutPanels2()
    {
        displayText.text = "T5 布局-2";
    }
    public void LayoutPanels3()
    {
        displayText.text = "T5 布局-3";
    }
    public void LayoutPanels4()
    {
        displayText.text = "T5 布局4";
    }

    public void OpenRuler()
    {
        displayText.text = "T6 打开标尺";
    }

    public void CloseRuler()
    {
        displayText.text = "T6 关闭标尺";
    }

    public void AdjustWindowLevel_up()
    {
        displayText.text = "T7 调节窗位-增高";
    }

    public void AdjustWindowLevel_down()
    {
        displayText.text = "T7 调节窗位-降低";
    }
    public void AdjustWindowWidth_up()
    {
        displayText.text = "T8 调节窗宽-增高";
    }

    public void AdjustWindowWidth_down()
    {
        displayText.text = "T8 调节窗宽-降低";
    }
    public void PresetWindow1()
    {
        displayText.text = "T9 预设窗位窗宽1";
    }
    public void PresetWindow2()
    {
        displayText.text = "T9 预设窗位窗宽2";
    }
    public void ActivateSequence()
    {
        displayText.text = "T10 激活病人片子序列";
    }

    public void DeactivateSequence()
    {
        displayText.text = "T10  关闭病人片子序列";
    }

    public void SwitchPanel()
    {
        displayText.text = "T11 切换面板（上下左右）";
    }

    public void OpenInfoWindow()
    {
        displayText.text = "T12 激活信息窗口";
    }

    public void CloseInfoWindow()
    {
        displayText.text = "T12 关闭信息窗口";
    }

    public void ResetToOriginal()
    {
        displayText.text = "T13 复原到初始图像";
    }

    public void UndoLastStep()
    {
        displayText.text = "T14 撤销上一步操作";
    }

    public void Flip_sp()
    {
        displayText.text = "T15 翻转-水平";
    }
    public void Flip_sz()
    {
        displayText.text = "T15 翻转-竖直";
    }
    public void clean_text()
    {
        displayText.text = " ";
    }
}
