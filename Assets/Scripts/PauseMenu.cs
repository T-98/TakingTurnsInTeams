using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;

    [SerializeField] private bool isPaused;

    public Slider sfxSlider;
    public Slider bgmSlider;
    public AudioMixerGroup sfxGroup;
    public AudioMixerGroup bgmGroup;
    private void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if(isPaused)
        {
            ActiveMenu();
        }

        else
        {
            DeactivateMenu();
        }
    }

    void ActiveMenu()
    {
        Time.timeScale = 0;
        //AudioListener.pause = true; //turns sounds off
        pauseMenuUI.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        //AudioListener.pause = true;
        pauseMenuUI.SetActive(false);
        isPaused = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void QuitGame1()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void ChangeVolume()
    {
        sfxGroup.audioMixer.SetFloat("VolumeSFX", sfxSlider.value);
        bgmGroup.audioMixer.SetFloat("VolumeBGM", bgmSlider.value);
    }

    public void ReturnMain ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
}

