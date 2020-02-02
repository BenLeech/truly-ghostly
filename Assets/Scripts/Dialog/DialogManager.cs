﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour {

    public TextAsset introFile;
    public dialog dialog;

    void Start() {
    }

    public void StartIntroDialog() {
        StartDialog(introFile);
    }

    private void StartDialog(TextAsset jsonFile) {
        dialog.SetMessages(readFromJsonFile(introFile).messages);
        dialog.StartDialog();
    }

    private DialogMessage readFromJsonFile(TextAsset jsonFile) {
        return JsonUtility.FromJson<DialogMessage>(introFile.text);
    }
}
