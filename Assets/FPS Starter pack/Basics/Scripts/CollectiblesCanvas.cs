using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectiblesCanvas : MonoBehaviour
{
    public Transform parent;

    private List<GameObject> goList = new List<GameObject>();

    public void DisplayStars(int nrOfStars, Sprite spr)
    {
        var go = new GameObject();
        go.transform.SetParent(parent);
        var img = go.AddComponent<Image>();
        img.sprite = spr;

        goList.Add(go);
    }

    public void ResetStars()
    {
        foreach (var item in goList)
        {
            Destroy(item);
        }
    }
}