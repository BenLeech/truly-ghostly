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
    public TextAsset revelationFile;
    public dialog dialog;

    public volatile bool isInDialog = false;

    public bool triggeredRevelation = false;

    void Start() {
    }

    public void StartIntroDialog() {
        isInDialog = true;
        dialog.SetMessages(readFromJsonFile(introFile).messages);
        dialog.StartDialog();
    }
    public void StartAwakeningDialog() {
        isInDialog = true;
        dialog.SetMessages(readFromJsonFile(awakeningFile).messages);
        dialog.StartDialog();
    }
    public void StartBradPreAwakeningDialog() {
        isInDialog = true;
        dialog.SetMessages(readFromJsonFile(bradPreAwakeningFile).messages);
        dialog.StartDialog();
    }
    public void StartBradPostAwakeningDialog() {
        isInDialog = true;  
        dialog.SetMessages(readFromJsonFile(bradPostAwakeningFile).messages);
        dialog.StartDialog();
    }
    public void StartGirlfriendPostAwakeningDialog() {
        isInDialog = true;
        dialog.SetMessages(readFromJsonFile(girlfriendPostAwakeningFile).messages);
        dialog.StartDialog();
    }
    public void StartRevelationDialog() {
        isInDialog = true;
        dialog.SetMessages(readFromJsonFile(revelationFile).messages);
        dialog.StartDialog();
        triggeredRevelation = true;
    }
    public void StartWineDialog() {
        isInDialog = true;
        dialog.SetMessages(readFromJsonFile(wineDialogFile).messages);
        dialog.StartDialog();
    }

    public void UnlockDialog() {
        isInDialog = false;
    }

    private DialogMessage readFromJsonFile(TextAsset jsonFile) {
        return JsonUtility.FromJson<DialogMessage>(jsonFile.text);
    }
}
