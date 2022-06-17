using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectionChecker : MonoBehaviour
{
    public enum Effect { LOAD_SCENE, OPEN_DOOR, SHOW_MESSAGE };
    public Effect effect;
    public float loadSceneDelay;
    public string sceneToLoad;
    public GameObject doorObjectToUnlock;
    public float messageTime;
    [TextArea(15, 20)] public string message;

    private GameObject messageCanvas;
    private GameObject collectibleCanvas;

    private void Start()
    {
        messageCanvas = GameObject.FindGameObjectWithTag("MessageCanvas");
        collectibleCanvas = GameObject.FindGameObjectWithTag("CollectibleCanvas");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collection>() != null)
        {
            var collection = other.GetComponent<Collection>();
            if (collection != null && collection.collectiblesCollected == collection.maxNrOfCollectibles)
            {
                switch (effect)
                {
                    case Effect.LOAD_SCENE:
                        StartCoroutine(LoadSceneAfterDelay());
                        break;
                    case Effect.OPEN_DOOR:
                        doorObjectToUnlock.SetActive(false);
                        break;
                    case Effect.SHOW_MESSAGE:
                        messageCanvas.GetComponent<MessageCanvas>().DisplayMessage(MessageType.BIG, message, messageTime);
                        break;
                }

                collection.collectiblesCollected = 0;
                //collectibleCanvas.GetComponent<CollectiblesCanvas>().DisplayStars(0, null);
                collectibleCanvas.GetComponent<CollectiblesCanvas>().ResetStars();
            }
        }
    }

    private IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(loadSceneDelay);
        SceneManager.LoadScene(sceneToLoad);
    }
}