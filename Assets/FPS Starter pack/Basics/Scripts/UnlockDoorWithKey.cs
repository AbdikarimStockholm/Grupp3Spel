using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoorWithKey : MonoBehaviour
{
    public GameObject doorObject;
    public int keyUsedToOpen;

    private void OnTriggerEnter(Collider other)
    {
        var playersKeys = other.GetComponent<Keys>();

        if (playersKeys != null)
        {
            if (keyUsedToOpen < playersKeys.keys.Length)
            {
                if (playersKeys.keys[keyUsedToOpen])
                {
                    doorObject.SetActive(false);
                }
            }
            else
            {
                Debug.LogWarning("Försökte låsa upp med nyckel med för högt nummer!");
            }
        }
    }
}