using UnityEngine;
using UnityEngine.InputSystem;

public class MoveByTouch : MonoBehaviour
{
    CharacterController characterController;
    PlayerInput playerInput;
    Transform cameraTransform;
    public float playerSpeed;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        cameraTransform = Camera.main.transform;
        playerSpeed = 1.5f;
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();
        
        characterController.Move(input * Time.deltaTime * playerSpeed);
    }
}
