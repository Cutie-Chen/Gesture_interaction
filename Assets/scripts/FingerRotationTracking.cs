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
    public EnhancedJointVelocityState ve;
    public GameObject game;
    //private IHand Hand;
    [SerializeField]
    private Hand hand;
    public GameObject ui;
    private void Awake()
    {
        //Hand = _hand as IHand;
    }
    private void Update()
    {
        // ��ȡ��ת����
       if (hand.GetJointPose(jointId, out Pose wristPose) &&
       jointDeltaProvider.GetRotationDelta(jointId, out Quaternion worldDeltaRotation))
        {
            //Vector3 worldTargetAxis = GetWorldTargetAxis(wristPose, config);
            worldDeltaRotation.ToAngleAxis(out float angle, out Vector3 axis);
            //float axisDifference = Mathf.Abs(Vector3.Dot(axis, worldTargetAxis));
            //float rotationOnTargetAxis = angle * axisDifference;
            // ����ת����Ӧ��������
            RectTransform uiRect = ui.GetComponent<RectTransform>();
            game.transform.rotation = Quaternion.Euler(0, 0, angle);

            uiRect.rotation *= worldDeltaRotation;
        }
    }
}
