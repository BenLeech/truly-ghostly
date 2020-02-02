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
            Debug.Log("Is this fire? " + currentObjectType);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {

            Debug.Log("Exit? " + currentObjectType);
        if (other.CompareTag(currentObjectType)) {
            Debug.Log("Is the same tag? " + currentObjectType + " and " + other.tag);
            if (other.gameObject == currentInterObj) {
                Debug.Log("Is the same object? " + currentInterObj + " and " + other.gameObject);
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
