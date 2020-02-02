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
        dialog.StartDialog(readFromJsonFile(introFile));
    }
    public void StartAwakeningDialog() {
        dialog.StartDialog(readFromJsonFile(awakeningFile));
    }
    public void StartBradPreAwakeningDialog() {
        dialog.StartDialog(readFromJsonFile(bradPreAwakeningFile));
    }
    public void StartBradPostAwakeningDialog() {
        dialog.StartDialog(readFromJsonFile(bradPostAwakeningFile));
    }
    public void StartGirlfriendPostAwakeningDialog() {
        dialog.StartDialog(readFromJsonFile(girlfriendPostAwakeningFile));
    }
    public void StartRevelationDialog() {
        dialog.StartDialog(readFromJsonFile(revelationFile));
        triggeredRevelation = true;
    }
    public void StartWineDialog() {
        dialog.StartDialog(readFromJsonFile(wineDialogFile));
    }

    private DialogMessage readFromJsonFile(TextAsset jsonFile) {
        return JsonUtility.FromJson<DialogMessage>(jsonFile.text);
    }
}
