using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public static PanelManager instance = null;

    public GameObject Panel_Play;
    public GameObject Panel_Pause;
    public GameObject Panel_PlayerDead;

    private void Awake()
    {
        instance = this;
    }
}