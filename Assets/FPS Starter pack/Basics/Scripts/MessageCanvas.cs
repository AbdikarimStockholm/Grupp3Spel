using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageCanvas : MonoBehaviour
{
    public GameObject smallMessage;
    public GameObject bigMessage;
    public GameObject noteMessage;
    public TextMeshProUGUI smallText;
    public TextMeshProUGUI bigText;
    public TextMeshProUGUI noteText;

    private void Start()
    {
        HideAllMessages();
    }

    public void DisplayMessage(MessageType type, string message, float time)
    {
        switch (type)
        {
            case MessageType.SMALL:
                smallMessage.SetActive(true);
                smallText.text = message;
                break;
            case MessageType.BIG:
                bigMessage.SetActive(true);
                bigText.text = message;
                break;
            case MessageType.NOTE:
                noteMessage.SetActive(true);
                noteText.text = message;
                break;
        }

        Invoke("HideAllMessages", time);
    }

    private void HideAllMessages()
    {
        smallMessage.SetActive(false);
        bigMessage.SetActive(false);
        noteMessage.SetActive(false);
    }
}