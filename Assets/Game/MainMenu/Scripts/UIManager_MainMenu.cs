using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager_MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject trMenu;
    [SerializeField] GameObject gameMenu;
    [SerializeField] GameObject legMenu;
    [SerializeField] GameObject handMenu;
    [SerializeField] GameObject nirvanaMenu;
    [SerializeField] GameObject trNrMenu;
    [SerializeField] GameObject fullBMenu;
    [SerializeField] GameObject backButton;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject minus_music;
    [SerializeField] GameObject plus_music;
    [SerializeField] GameObject minus_helper;
    [SerializeField] GameObject plus_helper;
    [SerializeField] GameObject minus_sens;
    [SerializeField] GameObject plus_sens;
    [SerializeField] GameObject minus_time;
    [SerializeField] GameObject plus_time;
    [SerializeField] GameObject music_count;
    [SerializeField] GameObject helper_count;
    [SerializeField] GameObject sens_count;
    [SerializeField] GameObject time_count;
    public GameObject lastMenu;
    public GameObject currentMenu;
    private TextMeshProUGUI m_c;
    private TextMeshProUGUI h_c;
    private TextMeshProUGUI s_c;
    private TextMeshProUGUI t_c;
    public GameObject Timer;
    public GameObject left_leg;
    public GameObject right_leg;
    public GameObject AudioManager;
    public AudioSource audioSource;

    public void Timer_stop()
    {
        mainMenu.SetActive(true);
        Timer.SetActive(false);
        left_leg.GetComponent<LegRotationController>().enabled = false;
        right_leg.GetComponent<LegRotationController>().enabled = false;
    }
    public void Start()
    {
        audioSource = GameObject.Find("AudioPhoneMusic").GetComponent<AudioSource>();
        Timer.SetActive(false);
        AudioManager = GameObject.Find("AudioManager");
        m_c = music_count.GetComponent<TextMeshProUGUI>();
        m_c.SetText(GameSettings.volumeMusic.ToString());
        h_c = helper_count.GetComponent<TextMeshProUGUI>();
        h_c.SetText(GameSettings.volumeVoice.ToString());
        s_c = sens_count.GetComponent<TextMeshProUGUI>();
        s_c.SetText(GameSettings.cameraSens.ToString());
        t_c = time_count.GetComponent<TextMeshProUGUI>();
        t_c.SetText((GameSettings.timeLevel/60).ToString()+":"+(GameSettings.timeLevel%60).ToString());
    }

    public void Update()
    {
        m_c.SetText(GameSettings.volumeMusic.ToString());
        h_c.SetText(GameSettings.volumeVoice.ToString());
        s_c.SetText(GameSettings.cameraSens.ToString());
        t_c.SetText((GameSettings.timeLevel/60).ToString()+":"+(GameSettings.timeLevel%60).ToString());
    }
    public void Button_Start()
    {
        mainMenu.SetActive(false);
        trNrMenu.SetActive(true);
        backButton.SetActive(true);
        lastMenu = mainMenu;
        currentMenu = trNrMenu;
        
    }
    public void Button_Settings()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
        backButton.SetActive(true);
        lastMenu = mainMenu;
        currentMenu = settingsMenu;
        
    }
    
    public void Button_Quit()
    {
        Application.Quit();
    }

    public void Button_Game()
    {
        gameMenu.SetActive(true);
        trNrMenu.SetActive(false);
        lastMenu = trNrMenu;
        currentMenu = gameMenu;
        
    }
    public void Button_Tr()
    {
        trMenu.SetActive(true);
        trNrMenu.SetActive(false);
        lastMenu = trNrMenu;
        
        currentMenu = trMenu;
        
    }
    public void Button_leg_game()
    {
        mainMenu.SetActive(true);
        gameMenu.SetActive(false);
        backButton.SetActive(false);
        SceneManager.LoadScene("Level_Soccer");
        
    }
    public void Button_hand_game()
    {
        mainMenu.SetActive(true);
        gameMenu.SetActive(false);
        backButton.SetActive(false);
        SceneManager.LoadScene("Basket");
        
    }
    public void Button_hand_tr()
    {
        handMenu.SetActive(true);
        trMenu.SetActive(false);
        lastMenu = trMenu;
        currentMenu = handMenu;
        
    }
    public void Button_leg_tr()
    {
        legMenu.SetActive(true);
        trMenu.SetActive(false);
        lastMenu = trMenu;
        currentMenu = legMenu;
        
    }
    public void Button_fullB()
    {
        fullBMenu.SetActive(true);
        trMenu.SetActive(false);
        lastMenu = trMenu;
        currentMenu = fullBMenu;
        
    }
    
    public void Button_nirvana()
    {
        nirvanaMenu.SetActive(true);
        trMenu.SetActive(false);
        lastMenu = trMenu;
        currentMenu = nirvanaMenu;
        
    }
    public void Button_mix()
    {
        //skfdjhskfdbjbkfds
        mainMenu.SetActive(true);
        trMenu.SetActive(false);
        backButton.SetActive(false);
        
    }

    public void Button_foot()
    {
        //kshaklaadadna
        mainMenu.SetActive(true);
        legMenu.SetActive(false);
        backButton.SetActive(false);
    }
    public void Button_allL()
    {
        //hlfiahsksfahs
        mainMenu.SetActive(true);
        legMenu.SetActive(false);
        backButton.SetActive(false);
    }
    public void Button_PrSp()
    {
        //kshaklaadadna
        mainMenu.SetActive(true);
        handMenu.SetActive(false);
        backButton.SetActive(false);
    }
    public void Button_emotes()
    {
        //hlfiahsksfahs
        mainMenu.SetActive(true);
        handMenu.SetActive(false);
        backButton.SetActive(false);
    }
    public void Button_feet_nirvana()
    {
        AudioManager.GetComponent<AudioManager_MainMenu>()._RasslabStop();
        left_leg.GetComponent<LegRotationController>().enabled = true;
        right_leg.GetComponent<LegRotationController>().enabled = true;
        Timer.SetActive(true);
        Timer.GetComponent<Timer_mainMenu>().Game_start();
        nirvanaMenu.SetActive(false);
        backButton.SetActive(false);
    }
    public void Button_breating()
    {
        //hlfiahsksfahs
        mainMenu.SetActive(true);
        nirvanaMenu.SetActive(false);
        backButton.SetActive(false);
    }
    public void Button_situps()
    {
        //hlfiahsksfahs
        mainMenu.SetActive(true);
        fullBMenu.SetActive(false);
        backButton.SetActive(false);
    }

    public void m_minus()
    {
        if (GameSettings.volumeMusic >= 10)
        {
            GameSettings.volumeMusic -= 10;
            audioSource.volume -= GameSettings.volumeMusic / 1000.0f;
        }
    }
    public void m_plus()
    {
        if (GameSettings.volumeMusic <= 90)
        {
            GameSettings.volumeMusic += 10;
            audioSource.volume += GameSettings.volumeMusic / 1000.0f;
        }
    }
    public void h_minus()
    {
        if (GameSettings.volumeVoice >= 10)
        {
            GameSettings.volumeVoice -= 10;
        }
    }
    public void h_plus()
    {
        if (GameSettings.volumeVoice <= 90)
        {
            GameSettings.volumeVoice += 10;
        }
    }
    public void s_minus()
    {
        if (GameSettings.cameraSens >= 10)
        {
            GameSettings.cameraSens -= 10;
        }
    }
    public void s_plus()
    {
        if (GameSettings.cameraSens <= 90)
        {
            GameSettings.cameraSens += 10;
        }
    }
    public void t_minus()
    {
        if (GameSettings.timeLevel >= 30)
        {
            GameSettings.timeLevel -= 30;
        }
    }
    public void t_plus()
    {
        if (GameSettings.timeLevel <= 240)
        {
            GameSettings.timeLevel += 30;
        }
    }
    

    public void Button_back(){
        if (lastMenu == mainMenu)
        {
            mainMenu.SetActive(true);
            trNrMenu.SetActive(false);
            trMenu.SetActive(false);
            nirvanaMenu.SetActive(false);
            handMenu.SetActive(false);
            legMenu.SetActive(false);
            currentMenu.SetActive(false);
            backButton.SetActive(false);
            currentMenu = mainMenu;
            lastMenu = null;
        }
        else if (lastMenu != mainMenu)
        {
            lastMenu.SetActive(true);
            currentMenu.SetActive(false); 
            if (lastMenu == nirvanaMenu)
            {
                currentMenu = lastMenu;
                lastMenu = trNrMenu;
            }
            else if (lastMenu == trMenu)
            {
                currentMenu = lastMenu;
                lastMenu = mainMenu;
            }
            else if (lastMenu == fullBMenu)
            {
                currentMenu = lastMenu;
                lastMenu = trNrMenu;
            }
            else if (lastMenu == legMenu)
            {
                currentMenu = lastMenu;
                lastMenu = trNrMenu;
            }
            else if (lastMenu == handMenu)
            {
                currentMenu = lastMenu;
                lastMenu = trNrMenu;
            }
            else if (lastMenu == gameMenu)
            {
                currentMenu = lastMenu;
                lastMenu = mainMenu;
            }
        }
    }
}
