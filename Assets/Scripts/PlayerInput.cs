using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    private GameObject player;
    private Movement movement;

    void Start() {
        player = GameObject.Find("Player");
        if(player == null) {
            throw new MissingReferenceException("Player object not found");
        }

        movement = player.GetComponent<Movement>();

        if(movement == null) {
            throw new MissingComponentException("Movement script not found on player object");
        }
    }

    void Update() {
        movement.SetMovementVelocity(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
    }
}
