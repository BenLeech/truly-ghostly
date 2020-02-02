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

    public bool triggeredRevelation = false;

    void Start() {
    }

    public void StartIntroDialog() {
        dialog.SetMessages(readFromJsonFile(introFile).messages);
        dialog.StartDialog();
    }
    public void StartAwakeningDialog() {
        dialog.SetMessages(readFromJsonFile(awakeningFile).messages);
        dialog.StartDialog();
    }
    public void StartBradPreAwakeningDialog() {
        dialog.SetMessages(readFromJsonFile(bradPreAwakeningFile).messages);
        dialog.StartDialog();
    }
    public void StartBradPostAwakeningDialog() {
        dialog.SetMessages(readFromJsonFile(bradPostAwakeningFile).messages);
        dialog.StartDialog();
    }
    public void StartGirlfriendPostAwakeningDialog() {
        dialog.SetMessages(readFromJsonFile(girlfriendPostAwakeningFile).messages);
        dialog.StartDialog();
    }
    public void StartRevelationDialog() {
        dialog.SetMessages(readFromJsonFile(revelationFile).messages);
        dialog.StartDialog();
        triggeredRevelation = true;
    }
    public void StartWineDialog() {
        dialog.SetMessages(readFromJsonFile(wineDialogFile).messages);
        dialog.StartDialog();
    }

    private DialogMessage readFromJsonFile(TextAsset jsonFile) {
        return JsonUtility.FromJson<DialogMessage>(jsonFile.text);
    }
}
