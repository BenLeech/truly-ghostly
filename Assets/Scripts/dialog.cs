using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class dialog : MonoBehaviour
{

    public string[] messages;
    public float typingSpeed;

    int index = 0;
    TextMesh myText;

    bool currentTextPlayLock = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject dialogSystem = new GameObject("dialogSystem");

        myText = dialogSystem.AddComponent<TextMesh>();
        myText.transform.localScale= (new Vector2(3, 3));

        StartCoroutine(Type());
        StartCoroutine(input());
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

    IEnumerator input()
     {
        while(index < messages.Length -1) {
            Debug.Log("Current text play lock: " + currentTextPlayLock.ToString());
            if (currentTextPlayLock) {
                yield return null;
            }
            if (Input.GetKeyDown(KeyCode.Return)) {
                myText.text = "";
                index++;
                StartCoroutine(Type());
            } 
            yield return null;
        }
     }

     bool ReachedEndOfSentence() {
         return myText.text == messages[index];
     }

    // Update is called once per frame
    void Update()
    {
        
    }
}
