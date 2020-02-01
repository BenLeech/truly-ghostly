using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour {

    public GameObject theGirlfriend;

    private Vector2[] theGirlfriendRoute = new Vector2[]{new Vector2(-300, -300), new Vector2(-300, 300),
        new Vector2(300, 300), new Vector2(300, -300)};

    void Start() {
        StartCoroutine("DoWalkRoute");
    }

    void Update() {
        
    }

    IEnumerator DoWalkRoute(int currentIndex) {
        yield return null;
    }
}
