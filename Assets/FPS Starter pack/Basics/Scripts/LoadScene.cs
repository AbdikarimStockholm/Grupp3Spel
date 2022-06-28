using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadScene : MonoBehaviour
{
    public string sceneName;
    public Image fadePanel;
    public TextMeshProUGUI endText;
    public string endMessage;
    public float fadeOutTime = 0.2f;
    public float darkTime;

    private void Start()
    {
        endText.text = "";
    }
    public void StartGame()
    {
        print("LADDAR");
        StartCoroutine(FadeOutAndLoad());
    }

    IEnumerator FadeOutAndLoad()   //FADE OUT (transparent to opaque)
    {
        float alpha = 0;
        for (float i = 0; i <= fadeOutTime; i += Time.deltaTime)
        {
            alpha = (i - 0) / (fadeOutTime - 0); //Normalize value between 0 and 1
            fadePanel.color = new Color(fadePanel.color.r, fadePanel.color.g, fadePanel.color.b, alpha);
            yield return null;
        }
        fadePanel.color = new Color(fadePanel.color.r, fadePanel.color.g, fadePanel.color.b, 1); // fix residual values
        endText.text = endMessage;
        yield return new WaitForSeconds(darkTime);
        SceneManager.LoadScene(sceneName);
    }
}