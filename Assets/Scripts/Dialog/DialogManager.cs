using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour {

    public TextAsset introFile;
    public dialog dialog;

    void Start() {
        StartIntroDialog();
    }

    public void StartIntroDialog() {
        dialog.SetMessages(readFromJsonFile(introFile).messages);
        dialog.StartDialog();
    }

    private DialogMessage readFromJsonFile(TextAsset jsonFile) {
        return JsonUtility.FromJson<DialogMessage>(introFile.text);
    }
}
