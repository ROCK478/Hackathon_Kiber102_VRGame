using UnityEngine;
using System.IO;

public class SaveLoadManager1 : MonoBehaviour
{
    // Путь к файлу сохранения. Application.persistentDataPath - это безопасный путь для VR/Android.
    private static string savePath => Path.Combine(Application.persistentDataPath, "vr_records.json");

    void Awake()
    {
        // Загружаем данные сразу при запуске приложения
        LoadRecords();
    }

    // Сохраняем данные при выходе из приложения или при потере фокуса (важно для VR/мобильных)
    void OnApplicationQuit()
    {
        SaveRecords();
    }

    void OnApplicationPause(bool pauseStatus)
    {
        // Если приложение ставится на паузу (например, пользователь снял шлем), сохраняем данные
        if (pauseStatus)
        {
            SaveRecords();
        }
    }

    // --- МЕТОД СОХРАНЕНИЯ ДАННЫХ ---
    public static void SaveRecords()
    {
        RecordData data = Records.ToData(); // Получаем объект данных из статического класса
        string json = JsonUtility.ToJson(data, true); // Сериализуем в JSON

        try
        {
            File.WriteAllText(savePath, json);
            Debug.Log("Records saved to: " + savePath);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Failed to save records: {e.Message}");
        }
    }

    // --- МЕТОД ЗАГРУЗКИ ДАННЫХ ---
    public static void LoadRecords()
    {
        if (File.Exists(savePath))
        {
            try
            {
                string json = File.ReadAllText(savePath);
                RecordData data = JsonUtility.FromJson<RecordData>(json);
                Records.UpdateFromData(data); // Обновляем статический класс
                Debug.Log("Records loaded successfully.");
            }
            catch (System.Exception e)
            {
                Debug.LogError($"Failed to load records: {e.Message}");
            }
        }
        else
        {
            Debug.Log("Save file not found. Using default values.");
        }
    }
}
