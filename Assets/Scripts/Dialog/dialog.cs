using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System;

public enum DIALOG_STATE {
    DIALOG,
    TYPING,
    OPTIONS,
    NONE
}

public class dialog : MonoBehaviour {

    public float typingSpeed;
    public GameObject optionPrefab;

    
    private Text myText;
    private UnityEngine.UI.Image textBackdrop;
    private UnityEngine.UI.Image continueBtn;
    
    private string[] messages;
    private List<GameObject> dialogOptions = new List<GameObject>();


    private int index = 0;
    private DIALOG_STATE currentDialogState = DIALOG_STATE.NONE;

    void Awake() {
        myText = GetComponentInChildren<Text>();
        textBackdrop = transform.Find("Backdrop").GetComponent<UnityEngine.UI.Image>();
        continueBtn = transform.Find("ContinueBtn").GetComponent<UnityEngine.UI.Image>();
    }

    void Start() {
        myText.color = Color.black;
        myText.text = "";
        StopDialog();
    }

    public void StartDialog(string[] dialogMessages) {
        if(currentDialogState != DIALOG_STATE.NONE) {
            return;
        }
        messages = dialogMessages;
        StopDialog();
        myText.gameObject.SetActive(true);
        textBackdrop.gameObject.SetActive(true);
        currentDialogState = DIALOG_STATE.DIALOG;
        StartCoroutine(Type());
        StartCoroutine(input());
    }

    public void StopDialog() {
        StopCoroutine(Type());
        StopCoroutine(input());
        myText.gameObject.SetActive(false);
        textBackdrop.gameObject.SetActive(false);
        continueBtn.gameObject.SetActive(false);
        index = 0;
        currentDialogState = DIALOG_STATE.NONE;
    }

    public void StartOptions(DialogOption[] options) {
        dialogOptions.Clear();
        for(int i = 0; i < options.Length - 1; i++) {
            GameObject option = Instantiate(optionPrefab, new Vector2(0, 0), Quaternion.identity);
            option.transform.SetParent(gameObject.transform);
            option.transform.position += new Vector3(0,i * 0.1f,0);
            option.GetComponent<Text>().text = options[i].action;
            dialogOptions.Add(option);
        }
    }

    IEnumerator Type() {
        currentDialogState = DIALOG_STATE.TYPING;
        continueBtn.gameObject.SetActive(false);
        foreach(char letter in messages[index].ToCharArray()) {
            myText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        currentDialogState = DIALOG_STATE.DIALOG;
        continueBtn.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
    }

    IEnumerator input() {
        while(index < messages.Length) {
            if (currentDialogState != DIALOG_STATE.TYPING && Input.GetKeyDown(KeyCode.Return)) {
                myText.text = "";
                index++;
                if(index < messages.Length ) {
                    StartCoroutine(Type());
                }
            } 
            yield return null;
        }
        StopDialog();
    }

}
