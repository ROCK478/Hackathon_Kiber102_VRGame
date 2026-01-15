using UnityEngine;

public class VRCameraRotationTrigger : MonoBehaviour
{
    [Header("Animator Settings")]
    public Animator animator;
    public string leftTrigger = "pronac";
    public string rightTrigger = "supynac";

    [Header("Angle Settings")]
    public float angleThreshold = 20f; // угол для срабатывания триггера
    public float resetThreshold = 5f;  // угол для сброса триггера

    private float initialLocalY; // начальный локальный угол камеры по Y
    private bool triggerLeftFired = false;
    private bool triggerRightFired = false;

    void Start()
    {
        // Фиксируем текущий локальный угол камеры по Y
        initialLocalY = transform.localEulerAngles.y;
        Debug.Log("Initial Local Y: " + initialLocalY);
    }

    void Update()
    {
        // Разница текущего локального Y и начального
        float yDifference = Mathf.DeltaAngle(initialLocalY, transform.localEulerAngles.y);
        Debug.Log("Y Difference: " + yDifference);

        // Поворот влево
        if (yDifference <= -angleThreshold && !triggerLeftFired)
        {
            Debug.Log("Left Trigger Fired!");
            triggerLeftFired = true;
            triggerRightFired = false;

            if (animator != null)
                animator.SetTrigger(leftTrigger);
        }

        // Поворот вправо
        if (yDifference >= angleThreshold && !triggerRightFired)
        {
            Debug.Log("Right Trigger Fired!");
            triggerRightFired = true;
            triggerLeftFired = false;

            if (animator != null)
                animator.SetTrigger(rightTrigger);
        }

        // Сброс триггеров, если голова вернулась в нейтральное положение
        if (Mathf.Abs(yDifference) < resetThreshold)
        {
            triggerLeftFired = false;
            triggerRightFired = false;
        }
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 300, 20), "Y Difference: " + Mathf.DeltaAngle(initialLocalY, transform.localEulerAngles.y).ToString("F2"));
        GUI.Label(new Rect(10, 30, 300, 20), "Left Trigger: " + triggerLeftFired);
        GUI.Label(new Rect(10, 50, 300, 20), "Right Trigger: " + triggerRightFired);
    }
}
