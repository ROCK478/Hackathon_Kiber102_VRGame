using System;
using UnityEngine;

public class test : MonoBehaviour
{
    public AudioSource audioSource_Buttons;
    public AudioClip buttonClick;
    [SerializeField] private GameObject camera;

    private float previousXRotation;
    public void Start()
    {
        previousXRotation = transform.localEulerAngles.y;
        audioSource_Buttons = GameObject.Find("Audio Source_button").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        Debug.Log($"{name} -> OnTriggerEnter с {other.name}");
    }



    void Update()
    {
        // Получаем текущее значение угла X
        float currentXRotation = transform.localEulerAngles.y;

        // Проверяем, изменилось ли значение с предыдущего кадра
        if (Mathf.Abs(currentXRotation - previousXRotation) > 45) // Используем Mathf.Epsilon для сравнения чисел с плавающей запятой
        {
            // Если изменилось, вызываем ваше пользовательское событие или логику
            Debug.Log($"Угол y изменился с {previousXRotation} на {currentXRotation}");
            sound();

            // Обновляем предыдущее значение
            previousXRotation = currentXRotation;
        }
    }


    private void sound()
    {
        audioSource_Buttons.PlayOneShot(buttonClick);
    }
}
