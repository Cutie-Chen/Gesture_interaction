using System;
using Oculus.Interaction.Input;
using UnityEngine;
using UnityEngine.Assertions;
using System.Collections.Generic;
using Oculus.Interaction.PoseDetection;
using TMPro;
using Oculus.Interaction;

public class SyncUIWithVelocity : MonoBehaviour
{
    public TextMeshProUGUI t;
    [SerializeField]
    private RectTransform _uiElement; // UI��RectTransform���
    [SerializeField]
    private HandJointId _jointToLog = HandJointId.HandStart;
    /*[SerializeField]
    public List<GameObject> objectsToSelect = new List<GameObject>(); // ��Ҫѡ��Ķ��UIԪ�أ�UI ���壩
    private List<RectTransform> objectRectTransforms = new List<RectTransform>(); // �洢����UIԪ�ص�*/
    [SerializeField]
    private JointVelocityActiveState.RelativeTo _relativeTo = JointVelocityActiveState.RelativeTo.World;
    public EnhancedJointVelocityState velocityState;
    public ActiveStateGroup activestategroup;
    public float sensitivity = 5f; // ����UI�˶������ж�
    private GameObject selectedObject = null; // ��ǰ��ѡ�е�UIԪ��
    //public Camera worldCamera; // ���ڼ�������������
    private void Awake()
    {
        if (_uiElement == null)
        {
            Debug.LogError("UI Element's RectTransform is not assigned!");
        }
    }
    /*void Start()
    {
        // ��ȡ����UIԪ�ص�RectTransform���
        foreach (var obj in objectsToSelect)
        {
            var rectTransform = obj.GetComponent<RectTransform>();
            if (rectTransform != null)
            {
                objectRectTransforms.Add(rectTransform);
            }
            else
            {
                Debug.LogError($"Object {obj.name} does not have a RectTransform component.");
            }
        }
    }*/

    private void Update()
    {
        if (activestategroup.Active)
        {
            // ��ȡ�ض��ؽڵ��ٶȺͷ���
            Vector3 wristPosition = velocityState.GetJointposition(_jointToLog);
            Vector3 wristVelocity = velocityState.GetJointVelocity(_jointToLog);
            Vector3 wristDirection = velocityState.GetJointDirection(_jointToLog, _relativeTo);

           /* foreach (var rectTransform in objectRectTransforms)
            {
                // ���UIԪ�ر����䣬��ͬ����λ��
                *//* if (_uiElement != null)
                 {*//*
                selectedObject = rectTransform.gameObject;
                if (selectedObject.tag == "select")
                {
                    t.text = "��ʼ�˶�";
                    rectTransform.anchoredPosition += new Vector2(wristPosition.x, wristPosition.y) * sensitivity;
                    break;
                }
            }*/

            /* // ����������ת��Ϊ��Ļ����
             Vector3 screenPosition = worldCamera.WorldToScreenPoint(wristPosition);

             // ����Ļ����ת��ΪUI����
             Vector2 uiPosition;
             RectTransformUtility.ScreenPointToLocalPointInRectangle(_uiElement.GetComponent<RectTransform>(), screenPosition, worldCamera, out uiPosition);

             // ʹ��ת�����UI����������UIԪ�ص�λ��
             _uiElement.anchoredPosition += uiPosition * sensitivity;*/
            // ʹ���ٶȸ���UIԪ�ص�λ��

           _uiElement.anchoredPosition += new Vector2(wristPosition.x, wristPosition.y) * sensitivity;

            }
                
                    // ����UIԪ�صķ��������Ҫ��
                    //_uiElement.rotation = Quaternion.LookRotation(wristDirection.normalized, Vector3.up);
                
            }
        }
   

