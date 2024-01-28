using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyEventManager
{
    public static Action eventVolumeRefresh;
    public static void CallVolumeRefresh()
    {
        eventVolumeRefresh?.Invoke();
    }

    public static Action eventPlayerDead;
    public static void CallPlayerDead()
    {
        eventPlayerDead?.Invoke();
    }

    public static Action eventIncreaseScore;
    public static void CallIncreaseScore()
    {
        eventIncreaseScore?.Invoke();
    }

    public static Action eventVolume0;
    public static void CallVolume0()
    {
        eventVolume0?.Invoke();
    }

    public static Action eventVolumeRecover;
    public static void CallVolumeRecover()
    {
        eventVolumeRecover?.Invoke();
    }
}