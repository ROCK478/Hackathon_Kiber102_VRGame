using System;
using UnityEngine;
// using Unity.Mathematics; // Эта библиотека не нужна для данного решения

public class Leg_y_movement_Fixed : MonoBehaviour
{
    public Transform masterObject; // Объект, за которым мы следим

    // Смещение по оси Z, которое можно настроить в инспекторе при необходимости
    public float zOffset = 0f;
    private float currentX;
    private float currentY;

    private void Start()
    {
        currentX = transform.eulerAngles.x;
        currentY = transform.eulerAngles.y;
    }

    // Мы будем использовать LateUpdate для надежности
    void LateUpdate()
    {
        if (masterObject == null)
        {
            Debug.LogError("Master object is not assigned!", this);
            return;
        }

        // 1. Получаем текущие углы X и Y нашего объекта (они не меняются)
        

        // 2. Получаем целевой угол Z от мастер-объекта
        float targetZ = masterObject.eulerAngles.z + zOffset;

        // 3. Собираем новое вращение, используя X и Y текущего объекта и целевой Z
        // Ключевой момент: Мы используем Quaternion.Euler, который корректно 
        // обрабатывает создание вращения из углов.
        Quaternion newRotation = Quaternion.Euler(currentX, currentY, targetZ);

        // 4. Применяем новое вращение
        transform.rotation = newRotation;
    }
}