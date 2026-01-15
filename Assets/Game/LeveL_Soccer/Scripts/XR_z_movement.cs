using Unity.Mathematics;
using UnityEngine;

public class XR_y_movement : MonoBehaviour
{
    public Transform masterObject; // Объект, за которым мы следим
    private float initialYOffset;  // Начальный сдвиг по оси Y

    void Start()
    {


            // Вычисляем начальный сдвиг по оси Y
            // Разница между мировым вращением дочернего и родительского объекта
            Vector3 offsetVector = transform.eulerAngles - masterObject.eulerAngles;
            initialYOffset = offsetVector.y;

    }

    void Update()
    {



        Vector3 masterEulerAngles = masterObject.eulerAngles;


        float targetYRotation = masterEulerAngles.y + initialYOffset;


        Vector3 currentRotation = transform.eulerAngles;


        Vector3 newRotation = new Vector3(
            currentRotation.x,
            targetYRotation,
            currentRotation.z
        );

        transform.eulerAngles = newRotation;
    }
}
