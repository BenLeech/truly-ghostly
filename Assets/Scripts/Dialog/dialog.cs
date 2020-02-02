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
    
    private List<GameObject> dialogOptions = new List<GameObject>();

    private int index = 0;
    private int optionsIndex = 0;
    private bool optionSelected = false;
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

    public void StartDialog(DialogMessage dialogMessage) {
        if(currentDialogState != DIALOG_STATE.NONE) {
            return;
        }
        StopDialog();
        myText.gameObject.SetActive(true);
        textBackdrop.gameObject.SetActive(true);
        currentDialogState = DIALOG_STATE.DIALOG;
        StartCoroutine(input(dialogMessage));
    }

    public void StopDialog() {
        StopAllCoroutines();
        myText.gameObject.SetActive(false);
        textBackdrop.gameObject.SetActive(false);
        continueBtn.gameObject.SetActive(false);
        index = 0;
        optionsIndex = 0;
        optionSelected = false;
        currentDialogState = DIALOG_STATE.NONE;
    }

    public void StartOptions(DialogOption[] options) {
        dialogOptions.Clear();
        continueBtn.gameObject.SetActive(false);
        for(int i = 0; i < options.Length; i++) {
            GameObject option = Instantiate(optionPrefab, new Vector2(0, 0), Quaternion.identity);
            option.transform.SetParent(gameObject.transform);
            option.transform.position = myText.gameObject.transform.position;
            option.transform.position += new Vector3(0,i * -20,0);
            option.GetComponent<Text>().text = options[i].action;
            dialogOptions.Add(option);
        }
        optionsIndex = 0;
        dialogOptions[0].GetComponent<Text>().color = Color.blue;
    }

    IEnumerator Type(string[] messages) {
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

    IEnumerator input(DialogMessage dialogMessage) {
        StartCoroutine(Type(dialogMessage.messages));
        while(index < dialogMessage.messages.Length) {
            TypingInput(dialogMessage.messages);
            yield return null;
        }
        if(dialogMessage.options.Length > 0) {
            optionSelected = false;
            currentDialogState = DIALOG_STATE.OPTIONS;
            StartOptions(dialogMessage.options);
            while(!optionSelected) {
                index = 0;
                if(Input.GetKeyDown(KeyCode.UpArrow)) {
                    dialogOptions[optionsIndex].GetComponent<Text>().color = Color.black;
                    optionsIndex = optionsIndex <= 0 ? dialogMessage.options.Length - 1 : optionsIndex - 1;
                    dialogOptions[optionsIndex].GetComponent<Text>().color = Color.blue;
                } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
                    dialogOptions[optionsIndex].GetComponent<Text>().color = Color.black;
                    optionsIndex = optionsIndex >= dialogMessage.options.Length - 1 ? 0 : optionsIndex + 1;
                    dialogOptions[optionsIndex].GetComponent<Text>().color = Color.blue;
                } else if (Input.GetKeyDown(KeyCode.Return)) {
                    optionSelected = true;
                    foreach(GameObject dialogOption in dialogOptions) {
                        Destroy(dialogOption);
                    }

                    while(index < dialogMessage.options[optionsIndex].messages.Length) {
                        TypingInput(dialogMessage.options[optionsIndex].messages);
                        yield return null;
                    }
                }
                yield return null;
            }
        }
        StopDialog();
    }

    private void TypingInput(string[] messages) {
        if (currentDialogState != DIALOG_STATE.TYPING && Input.GetKeyDown(KeyCode.Return)) {
                myText.text = "";
                index++;
                if(index < messages.Length ) {
                    StartCoroutine(Type(messages));
                }
        } 
    }

    private void OptionsInput(DialogOption[] options) {
        if (currentDialogState != DIALOG_STATE.OPTIONS) {
            return;
        }

        if(Input.GetKeyDown(KeyCode.UpArrow)) {
            optionsIndex = optionsIndex <= 0 ? options.Length - 1 : optionsIndex - 1;
        } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            optionsIndex = optionsIndex >= options.Length - 1 ? 0 : optionsIndex + 1;
        }
    }

}
