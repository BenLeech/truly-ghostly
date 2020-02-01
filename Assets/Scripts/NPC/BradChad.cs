﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BradChad : MonoBehaviour, INonPlayableCharacter {
    private Movement movement;

    void Start() {
        movement = GetComponent<Movement>();
    }

    public Vector2[] GetWalkRoute() {
        return new Vector2[]{
            new Vector2(3,2),
            new Vector2(3,-2),
            new Vector2(-3,-2),
            new Vector2(-3,2)
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
}