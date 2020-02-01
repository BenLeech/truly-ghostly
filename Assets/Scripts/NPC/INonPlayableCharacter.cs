using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INonPlayableCharacter {

    NPCAction[] GetActionQueue();

    Vector2 GetCurrentPosition();

    Movement GetMovement();

}