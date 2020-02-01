using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheGirlfriend : MonoBehaviour, INonPlayableCharacter {

    public Vector2[] getWalkRoute() {
        return new Vector2[]{
            new Vector2(-300,-300),
            new Vector2(-300,300),
            new Vector2(300,300),
            new Vector2(300,-300)
        };
    }
}
