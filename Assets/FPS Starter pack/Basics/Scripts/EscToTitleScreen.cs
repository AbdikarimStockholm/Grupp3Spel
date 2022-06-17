using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscToTitleScreen : MonoBehaviour
{
    public KeyCode quitKey = KeyCode.Escape;
    public string sceneName = "Title Screen";

    void Update()
    {
        if (Input.GetKeyDown(quitKey))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}