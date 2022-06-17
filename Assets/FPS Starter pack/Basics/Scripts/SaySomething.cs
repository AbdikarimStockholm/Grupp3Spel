using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SaySomething : MonoBehaviour
{
    // Använd UI-lager med undertexter
    // Animera karaktär? Överkurs?

    [TextArea(15, 20)] public string whatToSay;
    public float subtitleTime;
    public AudioClip clip;
    public bool repeatable = true;

    private Image subtitles;
    private TextMeshProUGUI subText;
    private bool canSay = true;

    private AudioSource source;

    private void Start()
    {
        subtitles = GameObject.FindGameObjectWithTag("SubtitlesCanvas").GetComponent<Image>();
        subtitles.enabled = false;

        subText = subtitles.gameObject.GetComponentInChildren<TextMeshProUGUI>();
        subText.enabled = false;

        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canSay)
        {
            if (clip != null)
            {
                source.PlayOneShot(clip);
            }

            subtitles.enabled = true;
            subText.enabled = true;
            subtitles.GetComponentInChildren<TextMeshProUGUI>().text = whatToSay;

            StartCoroutine(turnOffSubtitles(subtitleTime));

            if (!repeatable)
            {
                canSay = false;
            }
        }
    }

    private IEnumerator turnOffSubtitles(float time)
    {
        yield return new WaitForSeconds(time);
        subtitles.enabled = false;
        subText.enabled = false;
    }
}