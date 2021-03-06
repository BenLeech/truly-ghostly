﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour {

    public GameObject theGirlfriendObject;
    private INonPlayableCharacter theGirlfriend;

    public GameObject bradChadObject;
    private INonPlayableCharacter bradChad;

    void Start() {
        theGirlfriend = theGirlfriendObject.GetComponent<TheGirlfriend>();
        StartCoroutine("DoWalkRoute", theGirlfriend);

        bradChad = bradChadObject.GetComponent<BradChad>();
        StartCoroutine("DoWalkRoute", bradChad);
    }

    IEnumerator DoWalkRoute(INonPlayableCharacter character) {
        int currentIndex = 0;
        while(currentIndex < character.GetActionQueue().Length) {
            if(!character.GetMovement().GetIsMovingToPosition()) {
                yield return new WaitForFixedUpdate();
            }
            
            if(character.GetCurrentPosition() != character.GetActionQueue()[currentIndex].GetTargetPosition()) {
                character.GetMovement().MoveToPosition(character.GetActionQueue()[currentIndex].GetTargetPosition());
            } else {
                yield return new WaitForSeconds(character.GetActionQueue()[currentIndex].GetTimeDuration());
                currentIndex = currentIndex < character.GetActionQueue().Length - 1 ? currentIndex + 1 : 0;
            }

            yield return new WaitForFixedUpdate();
        }
    }
}
