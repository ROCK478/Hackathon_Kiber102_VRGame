

using System;

// Важно: добавьте атрибут [Serializable]
[Serializable]
public class RecordData
{
    public int easy_right_hand = 0;
    public int easy_left_hand = 0;
    public int medium_right_hand = 0;
    public int medium_left_hand = 0;
    public int hard_right_hand = 0;
    public int hard_left_hand = 0;
}

// Ваш статический класс для использования в игре
public static class Records
{
    public static int easy_right_hand = 0;
    public static int easy_left_hand = 0;
    public static int medium_right_hand = 0;
    public static int medium_left_hand = 0;
    public static int hard_right_hand = 0;
    public static int hard_left_hand = 0;
    
    // Метод для обновления статических полей из загруженных данных
    public static void UpdateFromData(RecordData data)
    {
        easy_right_hand = data.easy_right_hand;
        easy_left_hand = data.easy_left_hand;
        medium_right_hand = data.medium_right_hand;
        medium_left_hand = data.medium_left_hand;
        hard_right_hand = data.hard_right_hand;
        hard_left_hand = data.hard_left_hand;
    }

    // Метод для создания объекта данных из текущих статических полей
    public static RecordData ToData()
    {
        return new RecordData
        {
            easy_right_hand = easy_right_hand,
            easy_left_hand = easy_left_hand,
            medium_right_hand = medium_right_hand,
            medium_left_hand = medium_left_hand,
            hard_right_hand = hard_right_hand,
            hard_left_hand = hard_left_hand
        };
    }
}
