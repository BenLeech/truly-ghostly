using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidRegrets : MonoBehaviour
{

    private DialogManager dialogManager;

    public void Awake() {
        dialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();
    }
    public void Interact() {
        Debug.Log("I am drunk");
        dialogManager.StartIntroDialog();
    }
}
