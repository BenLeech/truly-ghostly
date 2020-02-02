using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour {

    public TextAsset introFile;
    public TextAsset awakeningFile;
    public TextAsset bradPreAwakeningFile;
    public TextAsset bradPostAwakeningFile;
    public TextAsset girlfriendPostAwakeningFile;
    public TextAsset wineDialogFile;
    public TextAsset winePreRevelationFile;
    public TextAsset winePreBradHintFile;
    public TextAsset revelationFile;
    public dialog dialog;

    public volatile bool isInDialog = false;

    public bool triggeredRevelation = false;
    public bool triggeredBradHint = false;

    public void HandleDialogEvent(string dialogEvent) {
        switch(dialogEvent) {
            case "SMACK_WINE":
                // TODO: wine smack
                break;
            case "LEAVE_WINE":
                // TODO: leave wine
                break;
            default:
                break;
        }
    }

    public void StartIntroDialog() {
        isInDialog = true;
        StartDialog(introFile);
    }

    private void StartDialog(TextAsset jsonFile) {
        isInDialog = true;
        dialog.StartDialog(readFromJsonFile(introFile));
    }
    public void StartAwakeningDialog() {
        isInDialog = true;
        dialog.StartDialog(readFromJsonFile(awakeningFile));
    }
    public void StartBradPreAwakeningDialog() {
        isInDialog = true;
        dialog.StartDialog(readFromJsonFile(bradPreAwakeningFile));
    }
    public void StartBradPostAwakeningDialog() {
        isInDialog = true;  
        dialog.StartDialog(readFromJsonFile(bradPostAwakeningFile));
        triggeredBradHint = true;
    }
    public void StartGirlfriendPostAwakeningDialog() {
        isInDialog = true;
        dialog.StartDialog(readFromJsonFile(girlfriendPostAwakeningFile));
    }
    public void StartRevelationDialog() {
        isInDialog = true;
        dialog.StartDialog(readFromJsonFile(revelationFile));
        triggeredRevelation = true;
    }
    public void StartWineDialog() {
        isInDialog = true;
        dialog.StartDialog(readFromJsonFile(wineDialogFile));
    }

    public void StartWinePreRevelationDialog() {
        isInDialog = true;
        dialog.StartDialog(readFromJsonFile(winePreRevelationFile));
    }

    public void StartWinePreBradHintDialog() {
        isInDialog = true;
        dialog.StartDialog(readFromJsonFile(winePreBradHintFile));
    }

    public void UnlockDialog() {
        isInDialog = false;
    }

    private DialogMessage readFromJsonFile(TextAsset jsonFile) {
        return JsonUtility.FromJson<DialogMessage>(jsonFile.text);
    }
}
