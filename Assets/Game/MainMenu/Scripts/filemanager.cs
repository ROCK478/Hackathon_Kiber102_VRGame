using UnityEngine;
using System.IO;

public class SaveLoadManager : MonoBehaviour
{
    // Путь к файлу сохранения (Application.persistentDataPath обеспечивает доступ на всех платформах)
    private static string savePath => Path.Combine(Application.persistentDataPath, "game_records.json");

    // Этот метод вызывается при запуске сцены (или игры, если объект не уничтожается)
    void Awake()
    {
        LoadRecords();
    }

    // --- МЕТОД СОХРАНЕНИЯ ДАННЫХ ---
    public static void SaveRecords()
    {
        // 1. Преобразуем статический класс в сериализуемый объект данных
        RecordData data = Records.ToData();

        // 2. Сериализуем объект в строку формата JSON
        string json = JsonUtility.ToJson(data, true); // true делает файл читабельным

        // 3. Записываем строку в файл
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
                // 1. Читаем файл в строку JSON
                string json = File.ReadAllText(savePath);

                // 2. Десериализуем строку обратно в объект данных
                RecordData data = JsonUtility.FromJson<RecordData>(json);

                // 3. Обновляем статический класс Records данными из файла
                Records.UpdateFromData(data);

                Debug.Log("Records loaded successfully.");
            }
            catch (System.Exception e)
            {
                Debug.LogError($"Failed to load records: {e.Message}");
                // Если загрузка не удалась (например, поврежден файл), инициализируем значения по умолчанию
                Records.UpdateFromData(new RecordData()); 
            }
        }
        else
        {
            Debug.Log("Save file not found. Using default records.");
        }
    }
}
