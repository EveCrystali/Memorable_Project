using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Transform playerTarget;
    public float moveSpeed;
    public Vector3 direction;
    public Vector3 orientation;
    private PlayerInput input;
    private Gamepad gamepad;
    public float turnSpeed;

    void Awake()
    {
        gamepad = Gamepad.current;
    }

    void Start()
    {
        input = new PlayerInput();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerTarget.position, moveSpeed * Time.deltaTime);

        if (gamepad != null)
        {
            direction = gamepad.leftStick.ReadValue();
            orientation = gamepad.rightStick.ReadValue();
        }

        MovePlayerTarget(direction);
        MovePlayerVision(orientation);
    }

    void MovePlayerTarget(Vector3 direction)
    {
        direction.Normalize(); // Évite les déplacements diagonaux plus rapides
        Vector3 moveDirection = new Vector3(direction.x, 0f, direction.y); // Utilise la composante Z à la place de Y
        playerTarget.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    void MovePlayerVision(Vector3 orientation)
    {
        
    }

}
