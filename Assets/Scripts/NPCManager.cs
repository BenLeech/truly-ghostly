using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour {

    public GameObject theGirlfriendObject;
    private INonPlayableCharacter theGirlfriend;

    void Start() {
        theGirlfriend = theGirlfriendObject.GetComponent<TheGirlfriend>();
        StartCoroutine("DoWalkRoute", theGirlfriend);
    }

    IEnumerator DoWalkRoute(INonPlayableCharacter character) {
        int currentIndex = 0;
        while(currentIndex < character.GetWalkRoute().Length) {
            if(!character.GetMovement().GetIsMovingToPosition() && character.GetCurrentPosition() != character.GetWalkRoute()[currentIndex]) {
                print("Move to position:" + character.GetWalkRoute()[currentIndex]);
                character.GetMovement().MoveToPosition(character.GetWalkRoute()[currentIndex]);
            }
            yield return null;
        }
    }
}
