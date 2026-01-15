using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GazeTarget_ : MonoBehaviour
{
    [Header("UI-индикатор")]
    public Canvas worldCanvas; // Канвас для отображения прогресса
    public Image progressCircle; // Круговой индикатор прогресса
    public float uiDistance = 1.5f; // Расстояние от объекта до UI

    [Header("События")]
    public UnityEvent onGazeEnter;
    public UnityEvent onGazeExit;
    public UnityEvent onGazeInteract;
    [Header("Звуки")]
    public AudioClip buttonFocus;  // звук при наведении
    public AudioClip buttonClick;  // звук при нажатии
    public AudioSource audioSource_Buttons; // аудио источник для воспроизведения звуков

    void Start()
    {
        audioSource_Buttons = GameObject.Find("Audio Source_button").GetComponent<AudioSource>();
        if (worldCanvas != null)
            worldCanvas.enabled = false;
    }

    public void OnGazeEnter()
    {
        if (worldCanvas != null)
            worldCanvas.enabled = true;

        onGazeEnter?.Invoke();
        audioSource_Buttons.PlayOneShot(buttonFocus);
    }

    public void OnGazeExit()
    {
        if (worldCanvas != null)
            worldCanvas.enabled = false;
        if (progressCircle != null)
            progressCircle.fillAmount = 0f;

        onGazeExit?.Invoke();
    }

    public void UpdateGazeProgress(float progress)
    {
        if (progressCircle != null)
            progressCircle.fillAmount = progress;

        if (worldCanvas != null)
            worldCanvas.transform.LookAt(Camera.main.transform);
    }

    public void OnGazeInteract()
    {
        onGazeInteract?.Invoke();
        audioSource_Buttons.PlayOneShot(buttonClick);
    }
}
