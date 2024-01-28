using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetImageForVolume : MonoBehaviour
{
    public Sprite volume0;
    public Sprite volume100;

    void Start()
    {        
        MyEventManager.eventVolumeRefresh += SetImage;        
        SetImage();
    }
    void OnDestroy()
    {
        MyEventManager.eventVolumeRefresh -= SetImage;
    }

    void SetImage()
    {
        if (ManagerOptions.instance.MusicFloat == 0f)
            GetComponent<Image>().sprite = volume0;
        else
            GetComponent<Image>().sprite = volume100;
    }
}