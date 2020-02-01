using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour {

    public GameObject theGirlfriendObject;
    private INonPlayableCharacter theGirlfriend;

    void Start() {
        theGirlfriend = theGirlfriendObject.GetComponent<TheGirlfriend>();
        StartCoroutine("DoWalkRoute", theGirlfriend);
        // theGirlfriend.GetMovement().MoveToPosition(theGirlfriend.GetWalkRoute()[0]);
    }

    IEnumerator DoWalkRoute(INonPlayableCharacter character) {
        int currentIndex = 0;
        while(currentIndex < character.GetWalkRoute().Length) {
            if(!character.GetMovement().GetIsMovingToPosition()) {
                yield return new WaitForFixedUpdate();
            }
            
            if(character.GetCurrentPosition() != character.GetWalkRoute()[currentIndex]) {
                character.GetMovement().MoveToPosition(character.GetWalkRoute()[currentIndex]);
            } else {
                currentIndex = currentIndex < character.GetWalkRoute().Length - 1 ? currentIndex + 1 : 0;
            }

            yield return new WaitForFixedUpdate();
        }
    }
}
