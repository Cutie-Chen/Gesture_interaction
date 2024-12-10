using UnityEngine;
using Oculus.Interaction.Input;
using Oculus.Interaction.PoseDetection;
using Oculus.Interaction;

public class FingerRotationTracking : MonoBehaviour
{
    public JointDeltaProvider jointDeltaProvider; // ����JointDeltaProvider
    public HandJointId jointId = HandJointId.HandIndex3; // ׷��ʳָĩ��
    [SerializeField, Interface(typeof(IHand))]
    private UnityEngine.Object _hand;
    private IHand Hand;
    public GameObject ui;
    private void Awake()
    {
        Hand = _hand as IHand;
    }
    private void Update()
    {
        // ��ȡ��ת����
       if (Hand.GetJointPose(jointId, out Pose wristPose) &&
       jointDeltaProvider.GetRotationDelta(jointId, out Quaternion worldDeltaRotation))
        {
            //Vector3 worldTargetAxis = GetWorldTargetAxis(wristPose, config);
            worldDeltaRotation.ToAngleAxis(out float angle, out Vector3 axis);
            //float axisDifference = Mathf.Abs(Vector3.Dot(axis, worldTargetAxis));
            //float rotationOnTargetAxis = angle * axisDifference;
            // ����ת����Ӧ��������
            RectTransform uiRect = ui.GetComponent<RectTransform>();

            uiRect.rotation *= worldDeltaRotation;
        }
    }
}
