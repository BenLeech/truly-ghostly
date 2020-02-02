using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class EndSceneController : MonoBehaviour {
    private DialogManager dialogManager;
    // Start is called before the first frame update
    public void Awake() {
        dialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();
    }
    void Start(){
        switch(CrossSceneInformation.ending) {
            case "SMACK_WINE":
                dialogManager.StartGoodEndingDialog();
                break;
            case "LEAVE_WINE":
                dialogManager.StartBadEndingDialog();
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
