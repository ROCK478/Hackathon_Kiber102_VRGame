using UnityEngine;
using TMPro;
using System.Collections;

public class Timer_mainMenu : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float timeRemaining;
    private bool timerRunning = false;
    private GameObject UIManager;

    // Цвет по умолчанию заменяем на тёмно-жёлтый
    private Color normalColor = new Color(1f, 0.85f, 0.3f);

    void Start()
    {
        UIManager = GameObject.Find("UIManager");
        timerText.color = normalColor; 
    }

    public void Game_start()
    {
        Debug.Log("Timer started");
        timeRemaining = GameSettings.timeLevel;
        timerRunning = true;
        StartCoroutine(TimerCoroutine());
    }

    private IEnumerator TimerCoroutine()
    {
        while (timerRunning && timeRemaining > 0)
        {
            int minutes = Mathf.FloorToInt(timeRemaining / 60f);
            int seconds = Mathf.FloorToInt(timeRemaining % 60f);
            timerText.text = $"{minutes:00}:{seconds:00}";

            // Мигающий эффект
            if (timeRemaining <= 10f)
            {
                timerText.color = (Mathf.FloorToInt(timeRemaining * 2) % 2 == 0)
                    ? Color.red
                    : normalColor;
            }
            else
            {
                timerText.color = normalColor;
            }

            yield return new WaitForSeconds(1f);
            timeRemaining -= 1f;
        }

        if (timeRemaining <= 0)
        {
            timerText.text = "00:00";
            timerText.color = normalColor;
            timerRunning = false;
            UIManager.GetComponent<UIManager_MainMenu>().Timer_stop();
        }
    }
}
