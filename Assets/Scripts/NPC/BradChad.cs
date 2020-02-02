using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BradChad : MonoBehaviour, INonPlayableCharacter {
    private Movement movement;

    void Start() {
        movement = GetComponent<Movement>();
    }

    public NPCAction[] GetActionQueue() {
        return new NPCAction[]{
            new NPCAction(new Vector2(3,2), 2),
            new NPCAction(new Vector2(3,-2), 2),
            new NPCAction(new Vector2(-3,-2), 2),
            new NPCAction(new Vector2(-3,2), 2)
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
        Debug.Log("I am Brad Chad!");
    }
    
}
