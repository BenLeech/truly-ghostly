using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour {
    private DialogManager dialogManager;
    // Start is called before the first frame update
    public void Awake() {
        dialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();
    }
    void Start() {
        dialogManager.StartIntroDialog();
    }

    // Update is called once per frame
    void Update() {
    }
}
