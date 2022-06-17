using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MessageType { SMALL, BIG, NOTE };

public class DisplayMessage : MonoBehaviour
{
    public MessageType messageType;
    public float messageTime = 3;
    //public Sprite noteSprite;
    //public float noteIconSize;
    public GameObject noteSprite;
    [TextArea(15,20)] public string message;

    private GameObject messageCanvas;

    private void Start()
    {
        messageCanvas = GameObject.FindGameObjectWithTag("MessageCanvas");
        noteSprite.SetActive(false);
        if (messageType == MessageType.NOTE)
        {
            noteSprite.SetActive(true);
        //    var go = new GameObject();
        //    go.transform.SetParent(transform);
        //    go.transform.localPosition = new Vector3(0, 0, 0);
        //    go.transform.localScale = new Vector3(noteIconSize, noteIconSize, noteIconSize);

        //    var img = go.AddComponent<SpriteRenderer>();
        //    img.sprite = noteSprite;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        messageCanvas.GetComponent<MessageCanvas>().DisplayMessage(messageType, message, messageTime);
    }
}