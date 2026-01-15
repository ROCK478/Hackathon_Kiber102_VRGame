using UnityEngine;

public class LegRotationController : MonoBehaviour
{
    [Header("References")]
    public Transform legs;
    public Transform pcCamera;
    public Transform vrHead;

    [Header("Settings")]
    public bool useVR = false;
    public float rotationMultiplier = 1f;
    public float smoothSpeed = 10f;

    [Header("Limits")]
    public float minX = -30f;
    public float maxX = 20f;

    [Header("Debug")]
    public float relativeCameraY;

    private float initialCameraY;   // начальный Y камеры

    void Start()
    {
        // Запоминаем исходный поворот камеры (в сцене)
        initialCameraY = GetCameraY();
    }

    void Update()
    {
        if (!useVR)
            UpdateLegs();
    }

    void LateUpdate()
    {
        if (useVR)
            UpdateLegs();
    }

    void UpdateLegs()
    {
        float camY = GetCameraY();

        // Делаем поворот ОТНОСИТЕЛЬНЫМ
        float relativeY = NormalizeAngle(camY - initialCameraY);
        relativeCameraY = relativeY;

        // Поворот ног по X
        float targetLegX = relativeY * rotationMultiplier;

        float currentX = NormalizeAngle(legs.localEulerAngles.x);

        float smoothedX = Mathf.Lerp(currentX, targetLegX, Time.deltaTime * smoothSpeed);

        float clampedX = Mathf.Clamp(smoothedX, minX, maxX);

        // применяем
        Vector3 rot = legs.localEulerAngles;
        legs.localEulerAngles = new Vector3(clampedX, rot.y, rot.z);
    }

    float GetCameraY()
    {
        return useVR ? vrHead.eulerAngles.y : pcCamera.eulerAngles.y;
    }

    float NormalizeAngle(float angle)
    {
        angle %= 360f;
        if (angle > 180f) angle -= 360f;
        return angle;
    }
}
