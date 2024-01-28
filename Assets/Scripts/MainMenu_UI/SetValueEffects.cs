using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetValueEffects : MonoBehaviour
{
    public float standartValueThisEffect = 1f;
    void Start()
    {
        MyEventManager.eventVolumeRefresh += SetValue;
        MyEventManager.eventVolume0 += Volume0;
        MyEventManager.eventVolumeRecover += SetValue;
        SetValue();
    }
    void OnDestroy()
    {
        MyEventManager.eventVolumeRefresh -= SetValue;
        MyEventManager.eventVolume0 -= Volume0;
        MyEventManager.eventVolumeRecover -= SetValue;
    }

    void SetValue()
    {
        GetComponent<AudioSource>().volume = standartValueThisEffect * ManagerOptions.instance.MusicFloat;
    }

    void Volume0()
    {
        GetComponent<AudioSource>().volume = 0f;
    }
}