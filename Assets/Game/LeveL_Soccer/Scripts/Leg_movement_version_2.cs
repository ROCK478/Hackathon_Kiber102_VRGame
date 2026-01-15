using UnityEngine;
using UnityEngine.XR;

public class Leg_movement_version_2 : MonoBehaviour
{
    public bool isRightLeg;

    private float minAngle = -90f;
    private float maxAngle = 0f;

    [SerializeField] private GameObject ball;

    private float initialXOffset; 
    private float initialHeadX;  

    public float kickForce = 4f;
    public float airMoveSpeed = 1f;

    void Start()
    {
        initialXOffset = transform.eulerAngles.x;

        // получить реальный угол головы в момент старта
        InputDevices.GetDeviceAtXRNode(XRNode.CenterEye)
            .TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion q);

        initialHeadX = q.eulerAngles.x;
    }

    void Update()
    {
        // включена ли нога
        bool shouldBeActive = (GameSettings.isRight && isRightLeg) || (!GameSettings.isRight && !isRightLeg);
        if (!shouldBeActive) return;

        // получаем угол головы
        Quaternion headRot;
        InputDevices.GetDeviceAtXRNode(XRNode.CenterEye)
            .TryGetFeatureValue(CommonUsages.deviceRotation, out headRot);

        float headPitch = headRot.eulerAngles.x;

        // считаем дельту относительно старта
        float delta = headPitch - initialHeadX;

        // усиливаем и лимитируем
        float clamped = ClampAngle(delta * 4.5f, minAngle, maxAngle);
        float targetXAngle = initialXOffset + clamped;

        // применяем
        Vector3 r = transform.eulerAngles;
        transform.eulerAngles = new Vector3(targetXAngle, r.y, r.z);
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        angle = Mathf.Repeat(angle + 180, 360) - 180;
        min = Mathf.Repeat(min + 180, 360) - 180;
        max = Mathf.Repeat(max + 180, 360) - 180;
        return Mathf.Clamp(angle, min, max);
    }
}

