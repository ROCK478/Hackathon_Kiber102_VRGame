using System;
using System.Threading;
using UnityEngine;

 
public class leg_movement : MonoBehaviour
{
    public bool isRightLeg;
    private Transform masterObject; // Объект, за которым мы следим
    private float minAngle = -90f;  // Минимальный угол (относительно начального офсета)
    private float maxAngle = 0f;   // Максимальный угол (относительно начального офсета)
    [SerializeField] private GameObject ball;
    private float initialXOffset;  // Начальный сдвиг по оси Y
    private float initialMasterX;  // Начальный угол Y мастер-объекта в момент старта
    public float kickForce = 4f;
    public float airMoveSpeed = 1f;
    void Start()
    {
        masterObject = Camera.main.transform;
        initialMasterX = masterObject.eulerAngles.x;
        initialXOffset = transform.eulerAngles.x; 
    }

    void LateUpdate()
    {
        bool shouldBeActive = (GameSettings.isRight && isRightLeg) || (!GameSettings.isRight && !isRightLeg);
        
        if (!shouldBeActive)
        {
            return;
        }
        float masterDeltaX = masterObject.eulerAngles.x- initialMasterX;
        float clampedDeltaX = ClampAngle(masterDeltaX*4.5f, minAngle, maxAngle);
        float targetXAngle = initialXOffset + clampedDeltaX;
        Vector3 currentRotation = transform.eulerAngles;
        Vector3 newEulerAngles = new Vector3(
            targetXAngle,
            currentRotation.y,
            currentRotation.z
        );
        transform.eulerAngles = newEulerAngles;
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject == ball)
        {
            Rigidbody rbb = collision.collider.GetComponent<Rigidbody>();
            rbb.linearVelocity = new Vector3(0, rbb.linearVelocity.y+1, 0);
            rbb.AddForce(Vector3.up * kickForce, ForceMode.Force);

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == ball)
        {
            Rigidbody rbb = collision.collider.GetComponent<Rigidbody>();
            rbb.linearVelocity = new Vector3(0, rbb.linearVelocity.y, 0);
        }
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        angle = Mathf.Repeat(angle + 180, 360) - 180;
        min = Mathf.Repeat(min + 180, 360) - 180;
        max = Mathf.Repeat(max + 180, 360) - 180;
        return Mathf.Clamp(angle, min, max);
    }

}