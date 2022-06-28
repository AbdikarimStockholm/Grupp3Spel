using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SaySomething : MonoBehaviour
{
    // Använd UI-lager med undertexter
    // Animera karaktär? Överkurs?

   
    [TextArea(10, 15)] public string whatToSay;
    public float subtitleTime;
    public AudioClip clip;
    public bool repeatable = true;

    private Image subtitles;
    private TextMeshProUGUI subText;
    private bool canSay = true;
    public bool CanSpeak;

    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    private void Start()
    {
        subtitles = GameObject.FindGameObjectWithTag("SubtitlesCanvas").GetComponent<Image>();
        subtitles.enabled = false;

        subText = subtitles.gameObject.GetComponentInChildren<TextMeshProUGUI>();
        subText.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (canSay)
        {
            if (clip != null)
            {
                if (!CanSpeak) return;
                source.PlayOneShot(clip);
            }

            subtitles.enabled = true;
            subText.enabled = true;

            subtitles.GetComponentInChildren<TextMeshProUGUI>().text = whatToSay;

            StartCoroutine(turnOffSubtitles());

            if (!repeatable)
            {
                canSay = false;
            }
        }
    }

    private IEnumerator turnOffSubtitles()
    {
        var time = !CanSpeak ? subtitleTime : clip.length;
        yield return new WaitForSeconds(time);

        subtitles.enabled = false;
        subText.enabled = false;
    }
}