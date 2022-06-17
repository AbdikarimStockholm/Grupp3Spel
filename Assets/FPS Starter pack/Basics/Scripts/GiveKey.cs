using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveKey : MonoBehaviour
{
    public int keyToGive;

    private void OnTriggerEnter(Collider other)
    {
        var playersKeys = other.GetComponent<Keys>();

        if (keyToGive < playersKeys.keys.Length)
        {
            other.GetComponent<Keys>().keys[keyToGive] = true;
        }
        else
        {
            Debug.LogWarning("F�rs�kte ge nyckel med f�r h�gt nummer!");
        }
    }
}