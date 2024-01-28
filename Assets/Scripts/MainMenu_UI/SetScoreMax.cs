using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetScoreMax : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<Text>().text = ManagerGameInfo.instance.MaxScore.ToString();
    }
}