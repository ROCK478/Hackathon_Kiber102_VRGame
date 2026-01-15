using System;
using UnityEngine;

public class HandRotation : MonoBehaviour
{
    public GameObject rightHand;
    public GameObject leftHand;
    [SerializeField] private Vector3 localOffset;

    private void Update()
    {
        if (GameSettings.isRight)
        {
            leftHand.SetActive(false);
            rightHand.SetActive(true);
            localOffset = new Vector3(0.3f, -0.1f, 0.1f);
        }
        else
        {
            rightHand.SetActive(false);
            leftHand.SetActive(true);
            localOffset = new Vector3(-0.15f, -0.15f, 0.1f);
        }
    }

    void LateUpdate()
    {
        if (Camera.main == null) return;

        // Устанавливаем позицию руки с учётом ориентации камеры
        transform.position = Camera.main.transform.TransformPoint(localOffset);

        // Повторяем поворот камеры
        transform.rotation = Camera.main.transform.rotation;
    }
}
