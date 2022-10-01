using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.OnScreen;
using UnityEngine.UI;

public class JoyStick : MonoBehaviour
{
    OnScreenStick joyStick;
    GameObject cont;
    public Canvas canvas;

    void Start()
    {
        joyStick = GetComponent<OnScreenStick>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            transform.position = Input.mousePosition;

            //joyStick.OnPointerDown(new PointerEventData(GetComponent<EventSystem>()));
        }
    }
}
