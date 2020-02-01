using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class dialog : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject newText = new GameObject("text", typeof(RectTransform));
        
        TextMesh myText = newText.AddComponent<TextMesh>();
        myText.text = "We did it!";


        // var newTextComp = newText.AddComponent<Text>();
        // newTextComp.text = "test";
        // newTextComp.font;
        // newTextComp.color = color;
        // newTextComp.fontSize = 16;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
