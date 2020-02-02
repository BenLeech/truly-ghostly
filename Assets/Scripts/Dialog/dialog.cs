using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System;

public class dialog : MonoBehaviour {

    public float typingSpeed;
    public GameObject optionPrefab;

    private int index = 0;
    private Text myText;
    private UnityEngine.UI.Image textBackdrop;
    private UnityEngine.UI.Image continueBtn;
    private string[] messages;

    private bool currentTextPlayLock = false;
    private bool messageLock = false;
    private List<GameObject> dialogOptions = new List<GameObject>();

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
        if(messageLock) {
            return;
        }
        messages = dialogMessages;
        StopDialog();
        myText.gameObject.SetActive(true);
        textBackdrop.gameObject.SetActive(true);
        StartCoroutine(Type());
        StartCoroutine(input());
        messageLock = true;
    }

    public void StopDialog() {
        StopCoroutine(Type());
        StopCoroutine(input());
        myText.gameObject.SetActive(false);
        textBackdrop.gameObject.SetActive(false);
        continueBtn.gameObject.SetActive(false);
        messageLock = false;
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

    public void StopOptions() {

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
        while(index < messages.Length) {
            if (Input.GetKeyDown(KeyCode.Return) && !currentTextPlayLock) {
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
