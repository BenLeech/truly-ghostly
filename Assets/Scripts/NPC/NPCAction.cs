using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAction {
    Vector2 targetPosition;
    float timeDuration;
    string animation;
    int direction;

    public NPCAction(Vector2 targetPosition, float timeDuration = 0, string animation = "", int direction = 0) {
        this.targetPosition = targetPosition;
        this.timeDuration = timeDuration;
        this.animation = animation;
        this.direction = direction;
    }

    public Vector2 GetTargetPosition() {
        return targetPosition;
    }

    public float GetTimeDuration() {
        return timeDuration;
    }

    public string GetAnimation() {
        return animation;
}

    public int GetDirection() {
        return direction;
    }
}
