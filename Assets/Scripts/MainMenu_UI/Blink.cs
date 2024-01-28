using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    readonly float speedChange = 1f;
    bool work = false;

    Text text;
    Color color;
    float tempAlpha;

    void Awake()
    {
        text = GetComponent<Text>();
        color = text.color;
        tempAlpha = color.a;
    }

    void Update()
    {
        if (!work)
            StartCoroutine(ChangeAlpha());
    }

    IEnumerator ChangeAlpha()
    {
        work = true;

        while (tempAlpha > 0.5)
        {
            tempAlpha -= Time.deltaTime * speedChange;
            if (tempAlpha < 0.5f)
                tempAlpha = 0.5f;
            text.color = new Color (color.r, color.g, color.b, tempAlpha);
            yield return null;
        }

        while (tempAlpha < 1f)
        {
            tempAlpha += Time.deltaTime * speedChange;
            if (tempAlpha > 1)
                tempAlpha = 1f;
            text.color = new Color(color.r, color.g, color.b, tempAlpha);
            yield return null;
        }
        work = false;
    }
}