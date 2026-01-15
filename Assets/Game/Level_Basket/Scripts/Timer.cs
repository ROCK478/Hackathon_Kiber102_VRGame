using UnityEngine;
using TMPro;
using System.Collections;

public class Timer : MonoBehaviour
{
    private TextMeshProUGUI timerText;
    private float timeRemaining;
    private bool timerRunning = false;
    public GameObject UIManager;
    private Color defaultColor; // <-- запоминаем исходный цвет

    void Start()
    {
        UIManager = GameObject.Find("UIManager");
        timerText = GetComponent<TextMeshProUGUI>();
        defaultColor = timerText.color; // <-- сохраняем цвет из инспектора
    }

    public void Game_start()
    {
        timeRemaining = GameSettings.timeLevel;
        timerRunning = true;
        StartCoroutine(TimerCoroutine());
    }

    private IEnumerator TimerCoroutine()
    {
        while (timerRunning && timeRemaining > 0)
        {
            // Формат 00:00
            int minutes = Mathf.FloorToInt(timeRemaining / 60f);
            int seconds = Mathf.FloorToInt(timeRemaining % 60f);
            timerText.text = $"{minutes:00}:{seconds:00}";

            // Мигающий эффект
            if (timeRemaining <= 10f)
            {
                timerText.color = (Mathf.FloorToInt(timeRemaining * 2) % 2 == 0)
                    ? Color.red
                    : defaultColor; // <-- возвращаем исходный
            }
            else
            {
                timerText.color = defaultColor; // <-- не белый!
            }

            yield return new WaitForSeconds(1f);
            timeRemaining -= 1f;
        }

        // Когда время вышло
        if (timeRemaining <= 0)
        {
            timerText.text = "00:00";
            timerText.color = defaultColor;
            timerRunning = false;
            UIManager.GetComponent<UIManager>().Timer_stop();
        }
    }
}
