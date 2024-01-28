using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerOptions : MonoBehaviour
{
    public static ManagerOptions instance = null;
    
    public float MusicFloat {get; private set;}

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;  
            DontDestroyOnLoad(gameObject);
            InitializeManagerOptions();
            MyEventManager.eventVolumeRefresh += VolumeChange;
        }           
        else
            Destroy(gameObject);
    }
    private void OnDestroy()
    {
        MyEventManager.eventVolumeRefresh -= VolumeChange;
    }

    public void VolumeChange()
    {
        if (MusicFloat == 1f)
            MusicFloat = 0f;
        else
            MusicFloat = 1f;       

        SaveOptions();
    }

    public void SaveOptions()
    {
        PlayerPrefs.SetFloat("MusicFloat", MusicFloat);
    }

    void InitializeManagerOptions()
    {
        if (PlayerPrefs.HasKey("MusicFloat"))
            MusicFloat = PlayerPrefs.GetFloat("MusicFloat");
        else
            MusicFloat = 1f;
    }
}