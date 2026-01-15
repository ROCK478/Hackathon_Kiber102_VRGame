using UnityEngine;

public class VRCameraSimulator : MonoBehaviour
{
    [Header("Настройки управления")]
    public float moveSpeed = 3f;
    public float lookSpeed = 2f;

    private float rotationX;
    private float rotationY;

    void Update()
    {
        rotationX += Input.GetAxis("Mouse X") * lookSpeed;
        rotationY -= Input.GetAxis("Mouse Y") * lookSpeed;
        rotationY = Mathf.Clamp(rotationY, -80f, 80f);
        transform.localRotation = Quaternion.Euler(rotationY, rotationX, 0f);
    }
}
