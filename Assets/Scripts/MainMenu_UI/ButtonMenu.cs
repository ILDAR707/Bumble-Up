using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonMenu : MonoBehaviour
{
    public void StartScene()
    {
        ButtonSound.instance.audioSource.Play();
        MyEventManager.CallVolumeRecover();
        Time.timeScale = 1f;

        if (gameObject.name == "Btn_PlayScene")
            SceneManager.LoadSceneAsync("PlayScene");
        else if (gameObject.name == "Btn_MainMenu")
            SceneManager.LoadSceneAsync("MainMenu");
    }

    public void PressVolumeChange()
    {
        MyEventManager.CallVolumeRefresh();
        ButtonSound.instance.audioSource.Play();
    }

    public void PressPause()
    {
        ButtonSound.instance.audioSource.Play();
        Time.timeScale = 0f;
        PanelManager.instance.Panel_Pause.SetActive(true);
    }

    public void PressContinue()
    {
        MyEventManager.CallVolumeRecover();
        ButtonSound.instance.audioSource.Play();
        Time.timeScale = 1f;
        PanelManager.instance.Panel_Pause.SetActive(false);
    }

    public void PressRestart()
    {
        MyEventManager.CallVolumeRecover();
        ButtonSound.instance.audioSource.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}