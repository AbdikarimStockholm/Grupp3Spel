using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PortalLoader : MonoBehaviour
{
    public UnityEvent OnTeleport;
    public PaintaingSO painting;
    public int requredIndex;
    public bool canSkip = false;
    public bool isLocked;
    private void OnTriggerEnter(Collider collision)
    {

        if (collision.CompareTag("Player"))
        {
            if (canSkip)
            {
                print("Test");
                OnTeleport.Invoke();
            }
            if (requredIndex == painting.paintingCount)
            {
                OnTeleport.Invoke();
            }
        }
       
    }
}
