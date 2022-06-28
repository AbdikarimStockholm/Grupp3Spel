using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Data", menuName = "Create Painting", order = 1)]
public class PaintaingSO : ScriptableObject
{
    public int paintingCount;


    private void OnValidate()
    {
        paintingCount = 0;
    }

}
