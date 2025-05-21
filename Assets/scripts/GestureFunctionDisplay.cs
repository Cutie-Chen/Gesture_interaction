using UnityEngine;
using TMPro;

public class GestureFunctionDisplay : MonoBehaviour
{
    public TextMeshProUGUI displayText;

    public void Zoom()
    {
        displayText.text = "T1 ����-�Ŵ�";
    }
    public void Scale()
    {
        displayText.text = "T1 ����-��С";
    }
    public void SwitchSlice_up()
    {
        displayText.text = "T2 �л��ϲ�-��";
    }
    public void SwitchSlice_down()
    {
        displayText.text = "T2 �л��ϲ�-��";
    }
    public void Pan()
    {
        displayText.text = "T3 ƽ�ƣ��������ң�";
    }

    public void Rotate()
    {
        displayText.text = "T4 ��ת��˳����ʱ�룩";
    }

    public void LayoutPanels1()
    {
        displayText.text = "T5 ����-1";
    }
    public void LayoutPanels2()
    {
        displayText.text = "T5 ����-2";
    }
    public void LayoutPanels3()
    {
        displayText.text = "T5 ����-3";
    }
    public void LayoutPanels4()
    {
        displayText.text = "T5 ����4";
    }

    public void OpenRuler()
    {
        displayText.text = "T6 �򿪱��";
    }

    public void CloseRuler()
    {
        displayText.text = "T6 �رձ��";
    }

    public void AdjustWindowLevel_up()
    {
        displayText.text = "T7 ���ڴ�λ-����";
    }

    public void AdjustWindowLevel_down()
    {
        displayText.text = "T7 ���ڴ�λ-����";
    }
    public void AdjustWindowWidth_up()
    {
        displayText.text = "T8 ���ڴ���-����";
    }

    public void AdjustWindowWidth_down()
    {
        displayText.text = "T8 ���ڴ���-����";
    }
    public void PresetWindow1()
    {
        displayText.text = "T9 Ԥ�贰λ����1";
    }
    public void PresetWindow2()
    {
        displayText.text = "T9 Ԥ�贰λ����2";
    }
    public void ActivateSequence()
    {
        displayText.text = "T10 �����Ƭ������";
    }

    public void DeactivateSequence()
    {
        displayText.text = "T10  �رղ���Ƭ������";
    }

    public void SwitchPanel()
    {
        displayText.text = "T11 �л���壨�������ң�";
    }

    public void OpenInfoWindow()
    {
        displayText.text = "T12 ������Ϣ����";
    }

    public void CloseInfoWindow()
    {
        displayText.text = "T12 �ر���Ϣ����";
    }

    public void ResetToOriginal()
    {
        displayText.text = "T13 ��ԭ����ʼͼ��";
    }

    public void UndoLastStep()
    {
        displayText.text = "T14 ������һ������";
    }

    public void Flip_sp()
    {
        displayText.text = "T15 ��ת-ˮƽ";
    }
    public void Flip_sz()
    {
        displayText.text = "T15 ��ת-��ֱ";
    }
    public void clean_text()
    {
        displayText.text = " ";
    }
}
