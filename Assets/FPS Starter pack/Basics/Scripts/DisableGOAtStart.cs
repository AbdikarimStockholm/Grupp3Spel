using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableGOAtStart : MonoBehaviour
{
    public GameObject[] GameObjectsToDisable;

    void Start()
    {
        foreach (var item in GameObjectsToDisable)
        {
            item.SetActive(false);
        }
    }
}