using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerationBox : MonoBehaviour
{
    public float accelerationSpeed;

    void OnTriggerEnter(Collider player)
    {
        if(player.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            player.GetComponent<PlayerMovement>().moveSpeed = accelerationSpeed;
        }
    }

    void OnTriggerExit(Collider player)
    {
        if (player.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            player.GetComponent<PlayerMovement>().moveSpeed = player.GetComponent<PlayerMovement>().originalMoveSpeed;
        }
    }
}
