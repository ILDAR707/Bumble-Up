using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerGameInfo : MonoBehaviour
{
    public static ManagerGameInfo instance = null;   
    public int MaxScore { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeManagerGameInfo();
        }            
        else
            Destroy(gameObject);
    }

    public void CompareMaxScore(int scoreInLevel)
    {
        if (scoreInLevel > MaxScore)
        {
            MaxScore = scoreInLevel;
            SaveGameInfo();
        }
    }

    public void SaveGameInfo()
    {
        PlayerPrefs.SetInt("MaxScore", MaxScore);
    }

    void InitializeManagerGameInfo()
    {
        if (PlayerPrefs.HasKey("MaxScore"))
            MaxScore = PlayerPrefs.GetInt("MaxScore");
        else
            MaxScore = 0;
    }
}