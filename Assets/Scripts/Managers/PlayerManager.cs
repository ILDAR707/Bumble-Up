using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance = null;
    public Text playerScoreText;  
    public int PlayerScoreInLevel { get; private set;}

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        MyEventManager.eventPlayerDead += PlayerDead;
        MyEventManager.eventIncreaseScore += IncreaseScore;
        playerScoreText.text = PlayerScoreInLevel.ToString();
    }

    private void OnDestroy()
    {
        MyEventManager.eventPlayerDead -= PlayerDead;
        MyEventManager.eventIncreaseScore -= IncreaseScore;
    }

    public void PlayerDead()
    {
        ManagerGameInfo.instance.CompareMaxScore(PlayerScoreInLevel);        
        StartCoroutine(Activation_Panel_PlayerDead());
    }

    void IncreaseScore()
    {
        PlayerScoreInLevel++;
        playerScoreText.text = PlayerScoreInLevel.ToString();
    }

    IEnumerator Activation_Panel_PlayerDead()
    {
        yield return new WaitForSeconds(1.5f);
        PanelManager.instance.Panel_Play.SetActive(false);
        PanelManager.instance.Panel_PlayerDead.SetActive(true);
        MyEventManager.CallVolume0();
    }
}