using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System;

public class dialog : MonoBehaviour {

    public float typingSpeed;

    private int index = 0;
    private Text myText;
    private UnityEngine.UI.Image textBackdrop;
    private UnityEngine.UI.Image continueBtn;
    private string[] messages;

    bool currentTextPlayLock = false;

    void Awake() {
        myText = GetComponentInChildren<Text>();
        textBackdrop = transform.Find("Backdrop").GetComponent<UnityEngine.UI.Image>();
        continueBtn = transform.Find("ContinueBtn").GetComponent<UnityEngine.UI.Image>();
    }

    void Start() {
        myText.color = Color.black;
        myText.text = "";
    }

    public void SetMessages(string[] dialogMessages) {
        messages = dialogMessages;
    }

    public void StartDialog() {
        StopDialog();
        myText.gameObject.SetActive(true);
        textBackdrop.gameObject.SetActive(true);
        StartCoroutine(Type());
        StartCoroutine(input());
    }

    public void StopDialog() {
        StopCoroutine(Type());
        StopCoroutine(input());
        myText.gameObject.SetActive(false);
        textBackdrop.gameObject.SetActive(false);
        continueBtn.gameObject.SetActive(false);
    }

    IEnumerator Type() {
        currentTextPlayLock = true;
        continueBtn.gameObject.SetActive(false);
        foreach(char letter in messages[index].ToCharArray()) {
            myText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        currentTextPlayLock = false;
        continueBtn.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
    }

    IEnumerator input() {
        while(index < messages.Length -1) {
            if (Input.GetKeyDown(KeyCode.Return) && !currentTextPlayLock) {
                myText.text = "";
                index++;
                StartCoroutine(Type());
            } 
            yield return null;
        }
        StopDialog();
     }

     bool ReachedEndOfSentence() {
         return myText.text == messages[index];
     }

}
