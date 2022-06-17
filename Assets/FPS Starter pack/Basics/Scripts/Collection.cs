using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    public int maxNrOfCollectibles;
    [HideInInspector] public int collectiblesCollected;

    private GameObject collectibleCanvas;

    void Start()
    {
        collectibleCanvas = GameObject.FindGameObjectWithTag("CollectibleCanvas");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            if (collectiblesCollected < maxNrOfCollectibles)
            {
                collectiblesCollected++;
                collectibleCanvas.GetComponent<CollectiblesCanvas>().DisplayStars(collectiblesCollected, other.GetComponentInChildren<SpriteRenderer>().sprite);
                Destroy(other.gameObject);
            }
        }
    }
}