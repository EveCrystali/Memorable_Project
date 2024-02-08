using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput input;
    private Gamepad gamepad;
    public float moveSpeed;
    public float rotationSpeed;
    public Transform playerTarget;

    private Quaternion targetRotation;

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
        Vector2 direction = Vector2.zero;
        Vector2 orientation = Vector2.zero;

        if (gamepad != null)
        {
            direction = gamepad.leftStick.ReadValue();
            orientation = gamepad.rightStick.ReadValue();
        }

        MovePlayerTarget(direction);
        RotatePlayerVision(orientation);
    }

    void MovePlayerTarget(Vector2 direction)
    {
        direction.Normalize();
        Vector3 moveDirection = new Vector3(direction.x, 0f, direction.y);
        playerTarget.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    void RotatePlayerVision(Vector2 orientation)
    {
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(orientation.x, 0f, orientation.y));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
