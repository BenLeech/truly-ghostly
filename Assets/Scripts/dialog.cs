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
    private string[] messages;

    bool currentTextPlayLock = false;

    void Awake() {
        myText = GetComponentInChildren<Text>();
        textBackdrop = GetComponentInChildren<UnityEngine.UI.Image>();
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
        myText.gameObject.SetActive(false);
        textBackdrop.gameObject.SetActive(false);
        StopCoroutine(Type());
        StopCoroutine(input());
    }

    IEnumerator Type() {
        currentTextPlayLock = true;
        foreach(char letter in messages[index].ToCharArray()) {
            myText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        currentTextPlayLock = false;
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
