using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INonPlayableCharacter {
    Vector2[] GetWalkRoute();

    Vector2 GetCurrentPosition();

    Movement GetMovement();

}