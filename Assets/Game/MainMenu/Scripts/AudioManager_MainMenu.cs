using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager_MainMenu : MonoBehaviour
{
    [Header("Настройки")]
    public List<AudioClip> audioClips_FirstScreen; // Список аудиофайлов
    public bool FirstScreen = true;
    public bool Rasslab_stop = false;
    public List<AudioClip> audioClips_RasslabStop;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        StartCoroutine(PlayAudioRoutine_FirstScreen());
    }

    public void _RasslabStop()
    {
        Rasslab_stop = true;
        FirstScreen = false;
        StartCoroutine(PlayAudioRoutine_RasslabStop());
    }

    IEnumerator PlayAudioRoutine_FirstScreen()
    {
        int index = 0;

        // Задержка перед первым воспроизведением
        yield return new WaitForSeconds(3f);

        while (true)
        {
            if (FirstScreen)
            {
                audioSource.clip = audioClips_FirstScreen[index];
                audioSource.Play();

                // Переход к следующему аудиофайлу
                index = (index + 1) % audioClips_FirstScreen.Count;
            }

            // Ждем 10 секунд перед следующей фразой
            yield return new WaitForSeconds(10f);
        }
    }

    IEnumerator PlayAudioRoutine_RasslabStop()
    {
        int index = 0;
        // Задержка перед первым воспроизведением
        yield return new WaitForSeconds(2f);

        while (true)
        {
            if (Rasslab_stop)
            {
                audioSource.clip = audioClips_RasslabStop[index];
                audioSource.Play();

                // Переход к следующему аудиофайлу
                index = (index + 1) % audioClips_RasslabStop.Count;
            }

            // Ждем 10 секунд перед следующей фразой
            yield return new WaitForSeconds(10f);
        }
    }
}
