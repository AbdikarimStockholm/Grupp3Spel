using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInAtStart : MonoBehaviour
{
    public Image fadePanel;
    public float fadeInTime;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()    //FADE IN (opaque to transparent)
    {
        float alpha = 1;
        for (float i = fadeInTime; i >= 0; i -= Time.deltaTime)
        {
            alpha = (i - 0) / (fadeInTime - 0); //Normalize value between 0 and 1
            fadePanel.color = new Color(fadePanel.color.r, fadePanel.color.g, fadePanel.color.b, alpha);
            yield return null;
        }
        fadePanel.color = new Color(fadePanel.color.r, fadePanel.color.g, fadePanel.color.b, 0); // fix residual values
    }
}