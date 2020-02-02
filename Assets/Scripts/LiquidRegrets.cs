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
        if (!dialogManager.triggeredRevelation) {
            dialogManager.StartWinePreRevelationDialog();
        } else if (!dialogManager.triggeredBradHint) {
            dialogManager.StartWinePreBradHintDialog();
        } else {
            dialogManager.StartWineDialog();
        }
            
    }
}
