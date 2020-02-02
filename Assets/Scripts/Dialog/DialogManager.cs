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
        StartDialog(introFile);
    }

    private void StartDialog(TextAsset jsonFile) {
        dialog.StartDialog(readFromJsonFile(introFile).messages);
    }
    public void StartAwakeningDialog() {
        dialog.StartDialog(readFromJsonFile(awakeningFile).messages);
    }
    public void StartBradPreAwakeningDialog() {
        dialog.StartDialog(readFromJsonFile(bradPreAwakeningFile).messages);
    }
    public void StartBradPostAwakeningDialog() {
        dialog.StartDialog(readFromJsonFile(bradPostAwakeningFile).messages);
    }
    public void StartGirlfriendPostAwakeningDialog() {
        dialog.StartDialog(readFromJsonFile(girlfriendPostAwakeningFile).messages);
    }
    public void StartRevelationDialog() {
        dialog.StartDialog(readFromJsonFile(revelationFile).messages);
        triggeredRevelation = true;
    }
    public void StartWineDialog() {
        dialog.StartDialog(readFromJsonFile(wineDialogFile).messages);
    }

    private DialogMessage readFromJsonFile(TextAsset jsonFile) {
        return JsonUtility.FromJson<DialogMessage>(jsonFile.text);
    }
}
