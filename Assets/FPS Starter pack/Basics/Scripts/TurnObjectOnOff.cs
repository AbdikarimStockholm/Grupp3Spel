using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnObjectOnOff : MonoBehaviour
{
    public GameObject theObject;
    public enum WhatToDo { TURN_OFF, TURN_ON, TOGGLE}
    public WhatToDo whatToDo = WhatToDo.TOGGLE;

    private void OnTriggerEnter(Collider other)
    {
        switch (whatToDo)
        {
            case WhatToDo.TURN_OFF:
                theObject.SetActive(false);
                break;
            case WhatToDo.TURN_ON:
                theObject.SetActive(true);
                break;
            case WhatToDo.TOGGLE:
                theObject.SetActive(!theObject.activeSelf);
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (whatToDo == WhatToDo.TOGGLE)
        {
            theObject.SetActive(!theObject.activeSelf);
        }
    }
}