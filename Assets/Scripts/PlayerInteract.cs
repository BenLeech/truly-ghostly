using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerInteract : MonoBehaviour
{


    public GameObject currentInterObj = null;
    public string currentObjectType;

    enum InteractableTags {
        BoxOfWine,
        BradChad,
        Girlfriend
    }

    void Update() {
        if (Input.GetButtonDown("Interact") && currentInterObj) {
            // what is it
            currentInterObj.SendMessage("Interact");
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (TagIsInteractable(other)) {
            currentInterObj = other.gameObject;
            currentObjectType = other.tag;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {

        if (other.CompareTag(currentObjectType)) {
            if (other.gameObject == currentInterObj) {
                currentInterObj = null;
                currentObjectType = null;
            }
        }
    }

    private bool TagIsInteractable(Collider2D other) {
        return other.CompareTag(InteractableTags.BoxOfWine.ToString()) || 
        other.CompareTag(InteractableTags.BradChad.ToString()) || 
        other.CompareTag(InteractableTags.Girlfriend.ToString());
    }
}
