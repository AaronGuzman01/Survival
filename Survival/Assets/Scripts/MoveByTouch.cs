using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveByTouch : MonoBehaviour
{
    CharacterController characterController;
    PlayerInput playerInput;
    Transform cameraTransform;
    public float playerSpeed;
    Vector2 firstTouch;
    Vector2 secondTouch;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        cameraTransform = Camera.main.transform;
        playerSpeed = 4f;
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();
        
        characterController.Move(input * Time.deltaTime * playerSpeed);

        /*
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == UnityEngine.TouchPhase.Began)
            {
                firstTouch = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                Debug.Log("First Touch Set");

                Debug.DrawLine(transform.position, firstTouch, Color.red);
            }
            else
            {
                secondTouch = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                Debug.Log("Second Touch Set");

                Vector3 distance = (secondTouch - firstTouch).normalized;

                transform.Translate(distance * Time.deltaTime * playerSpeed);
                firstTouch = firstTouch + (secondTouch - firstTouch);
            }

            //transform.position = transform.position + distance
        }
        */
    }
}
