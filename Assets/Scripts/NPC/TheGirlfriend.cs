using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheGirlfriend : MonoBehaviour, INonPlayableCharacter {

    private Movement movement;
    private DialogManager dialogManager;

    public void Awake() {
        dialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();
    }

    void Start() {
        movement = GetComponent<Movement>();
    }

    public NPCAction[] GetActionQueue() {
        return new NPCAction[]{
            new NPCAction(this.gameObject.transform.position)
        };
    }

    public Vector2 GetCurrentPosition() {
        return gameObject.transform.position;
    }

    public Movement GetMovement() {
        if(movement == null) {
            movement = GetComponent<Movement>();
        }
        return movement;
    }

    public void Interact() {
        if (!dialogManager.triggeredRevelation) {
            dialogManager.StartRevelationDialog();
        } else {
            dialogManager.StartGirlfriendPostAwakeningDialog();
        }

    }
}
