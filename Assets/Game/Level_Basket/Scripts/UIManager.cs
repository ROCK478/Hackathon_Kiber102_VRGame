using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject Button_stop;
    public GameObject Button_start;
    public GameObject Button_howPlay;
    public GameObject Button_backToFirstScreen;
    public GameObject Button_settings;
    public GameObject Easy_difficulty;
    public GameObject Medium_difficulty;
    public GameObject Hard_difficulty;
    public GameObject Competitive_mode;
    public GameObject Training_mode;
    public GameObject Right_hand_button;
    public GameObject Left_hand_button;
    public GameObject back_button;
    public GameObject canvas;
    public GameObject TMP_Orientation;
    public GameObject TMP_LevelQuality;
    public GameObject TMP_Mode;
    public GameObject Ball;
    public GameObject Timer_UI;
    public GameObject Statistics_UI;
    public GameObject Count_UI;
    public GameObject easy_right;
    public GameObject easy_left;
    public GameObject mid_right;
    public GameObject mid_left;
    public GameObject hard_right;
    public GameObject hard_left;

    public void Start()
    {
        Ball.SetActive(false);
        Button_start.SetActive(true);
        Button_backToFirstScreen.SetActive(true);
        Button_settings.SetActive(true);
        Button_howPlay.SetActive(true);
        Button_backToFirstScreen.SetActive(true);
        Easy_difficulty.SetActive(false);
        Easy_difficulty.transform.Find("Image").gameObject.SetActive(false);
        Medium_difficulty.SetActive(false);
        Medium_difficulty.transform.Find("Image").gameObject.SetActive(false);
        Hard_difficulty.SetActive(false);
        Hard_difficulty.transform.Find("Image").gameObject.SetActive(false);
        back_button.SetActive(false);
        Competitive_mode.SetActive(false);
        Competitive_mode.transform.Find("Image").gameObject.SetActive(false);
        Training_mode.SetActive(false);
        Training_mode.transform.Find("Image").gameObject.SetActive(false);
        Right_hand_button.SetActive(false);
        Right_hand_button.transform.Find("Image").gameObject.SetActive(false);
        Left_hand_button.SetActive(false);
        Left_hand_button.transform.Find("Image").gameObject.SetActive(false);
        TMP_Mode.SetActive(false);
        TMP_LevelQuality.SetActive(false);
        TMP_Orientation.SetActive(false);
        Button_stop.SetActive(false);
        Statistics_UI.SetActive(true);
        Timer_UI.SetActive(false);
        Count_UI.SetActive(false);
    }
    
    public void Timer_stop()
    {
        Start();
    }

    public void Update()
    {
        
        easy_right.GetComponent<TextMeshProUGUI>().SetText(Records.easy_right_hand.ToString());
        easy_left.GetComponent<TextMeshProUGUI>().SetText(Records.easy_left_hand.ToString());
        mid_right.GetComponent<TextMeshProUGUI>().SetText(Records.medium_right_hand.ToString());
        mid_left.GetComponent<TextMeshProUGUI>().SetText(Records.medium_left_hand.ToString());
        hard_right.GetComponent<TextMeshProUGUI>().SetText(Records.hard_right_hand.ToString());
        hard_left.GetComponent<TextMeshProUGUI>().SetText(Records.hard_left_hand.ToString());
        
    }
    public void Button_Start()
    {
        Button_start.SetActive(false);
        Button_backToFirstScreen.SetActive(false);
        Button_settings.SetActive(false);
        Button_howPlay.SetActive(false);
        Button_backToFirstScreen.SetActive(false);
        Button_settings.SetActive(false);
        Button_howPlay.SetActive(false);
        Easy_difficulty.SetActive(false);
        Easy_difficulty.transform.Find("Image").gameObject.SetActive(false);
        Medium_difficulty.SetActive(false);
        Medium_difficulty.transform.Find("Image").gameObject.SetActive(false);
        Hard_difficulty.SetActive(false);
        Hard_difficulty.transform.Find("Image").gameObject.SetActive(false);
        back_button.SetActive(false);
        Competitive_mode.SetActive(false);
        Competitive_mode.transform.Find("Image").gameObject.SetActive(false);
        Training_mode.SetActive(false);
        Training_mode.transform.Find("Image").gameObject.SetActive(false);
        Right_hand_button.SetActive(false);
        Right_hand_button.transform.Find("Image").gameObject.SetActive(false);
        Left_hand_button.SetActive(false);
        Left_hand_button.transform.Find("Image").gameObject.SetActive(false);
        TMP_Mode.SetActive(false);
        TMP_LevelQuality.SetActive(false);
        TMP_Orientation.SetActive(false);
        Ball.SetActive(true);
        Button_stop.SetActive(true);
        Timer_UI.SetActive(true);
        Timer_UI.GetComponent<Timer>().Game_start();
        Statistics_UI.SetActive(false);
        Count_UI.SetActive(true);

    }
    
    public void Button_Stop()
    {
        Start();
    }

    public void left_hand_button()
    {
        GameSettings.isRight = false;
        Left_hand_button.transform.Find("Image").gameObject.SetActive(true);
        Right_hand_button.transform.Find("Image").gameObject.SetActive(false);

        
    }
    public void right_hand_button()
    {
        GameSettings.isRight = true; 
        Left_hand_button.transform.Find("Image").gameObject.SetActive(false);
        Right_hand_button.transform.Find("Image").gameObject.SetActive(true);
        
    }
    public void training_mode()
    {
        GameSettings.trainingMode = true;
        Training_mode.transform.Find("Image").gameObject.SetActive(true);
        Competitive_mode.transform.Find("Image").gameObject.SetActive(false);
        
    }
    public void competitive_mode()
    {
        GameSettings.trainingMode = false;
        Training_mode.transform.Find("Image").gameObject.SetActive(false);
        Competitive_mode.transform.Find("Image").gameObject.SetActive(true);
        
    }
    public void Button_Settings()
    {
        Button_backToFirstScreen.SetActive(false);   
        Button_settings.SetActive(false);
        Button_howPlay.SetActive(false);
        Easy_difficulty.SetActive(true);
        Medium_difficulty.SetActive(true);
        Hard_difficulty.SetActive(true);
        back_button.SetActive(true);
        Competitive_mode.SetActive(true);
        Training_mode.SetActive(true);
        Right_hand_button.SetActive(true);
        Left_hand_button.SetActive(true);
        TMP_Mode.SetActive(true);
        TMP_LevelQuality.SetActive(true);
        TMP_Orientation.SetActive(true);
        if (GameSettings.isRight)
        {
            Right_hand_button.transform.Find("Image").gameObject.SetActive(true);
        }
        else
        {
            Left_hand_button.transform.Find("Image").gameObject.SetActive(true);
        }
        if (GameSettings.trainingMode)
        {
            Training_mode.transform.Find("Image").gameObject.SetActive(true);
        }
        else
        {
            Competitive_mode.transform.Find("Image").gameObject.SetActive(true);
        }
        if (GameSettings.difficultyLevel == 1)
        {
            Easy_difficulty.transform.Find("Image").gameObject.SetActive(true);
        }
        else if (GameSettings.difficultyLevel == 2)
        {
            Medium_difficulty.transform.Find("Image").gameObject.SetActive(true);
        }
        else if (GameSettings.difficultyLevel == 3)
        {
            Hard_difficulty.transform.Find("Image").gameObject.SetActive(true);
        }
    }
    public void Back_button()
    {
        Button_backToFirstScreen.SetActive(true);   
        Button_settings.SetActive(true);
        Button_howPlay.SetActive(true);
        Easy_difficulty.SetActive(false);
        Medium_difficulty.SetActive(false);
        Hard_difficulty.SetActive(false);
        back_button.SetActive(false);
        Competitive_mode.SetActive(false);
        Training_mode.SetActive(false);
        Right_hand_button.SetActive(false);
        Left_hand_button.SetActive(false);
        TMP_Mode.SetActive(false);
        TMP_LevelQuality.SetActive(false);
        TMP_Orientation.SetActive(false);
        Easy_difficulty.transform.Find("Image").gameObject.SetActive(false);
        Medium_difficulty.transform.Find("Image").gameObject.SetActive(false);
        Hard_difficulty.transform.Find("Image").gameObject.SetActive(false);
        Training_mode.transform.Find("Image").gameObject.SetActive(false);
        Competitive_mode.transform.Find("Image").gameObject.SetActive(false);
        Left_hand_button.transform.Find("Image").gameObject.SetActive(false);
        Right_hand_button.transform.Find("Image").gameObject.SetActive(false);
    }

    public void back_to_main_screen()
    {
        SceneManager.LoadScene("MainMenu_");
    }

    public void Easy_Difficulty()
    {
        GameSettings.difficultyLevel = 1;
        Easy_difficulty.transform.Find("Image").gameObject.SetActive(true);
        Medium_difficulty.transform.Find("Image").gameObject.SetActive(false);
        Hard_difficulty.transform.Find("Image").gameObject.SetActive(false);
    }
    public void Medium_Difficulty()
    {
        GameSettings.difficultyLevel = 2;
        Easy_difficulty.transform.Find("Image").gameObject.SetActive(false);
        Medium_difficulty.transform.Find("Image").gameObject.SetActive(true);
        Hard_difficulty.transform.Find("Image").gameObject.SetActive(false);
    }
    public void Hard_Difficulty()
    {
        GameSettings.difficultyLevel = 3;
        Easy_difficulty.transform.Find("Image").gameObject.SetActive(false);
        Medium_difficulty.transform.Find("Image").gameObject.SetActive(false);
        Hard_difficulty.transform.Find("Image").gameObject.SetActive(true);
    }
}
