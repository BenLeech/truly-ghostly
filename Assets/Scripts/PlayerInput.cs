using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    private GameObject player;
    private Movement movement;

    private DialogManager dialogManager;

    void Awake() {
        dialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();

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
        if(!dialogManager.isInDialog) {
            movement.SetMovementVelocity(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        }
    }
}
