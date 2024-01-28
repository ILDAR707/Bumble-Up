using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetScore : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<Text>().text = PlayerManager.instance.PlayerScoreInLevel.ToString();
    }
}