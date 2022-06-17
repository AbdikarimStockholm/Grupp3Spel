using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    public int maxNrOfKeys;

    public bool[] keys;

    private void Start()
    {
        keys = new bool[maxNrOfKeys];
    }
}