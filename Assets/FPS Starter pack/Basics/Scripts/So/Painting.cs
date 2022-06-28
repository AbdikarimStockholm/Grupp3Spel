using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Painting : MonoBehaviour
{
    public PaintaingSO painting;
    public UnityEvent OnCollect;
    public AudioSource source;
    public float destroyDuration;

    public void CollectPainting()
    {
        OnCollect?.Invoke();
        painting.paintingCount++;
        source.PlayOneShot(source.clip);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        CollectPainting();
    }


}
