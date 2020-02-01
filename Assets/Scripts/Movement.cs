using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float movementSpeed = 1f;
    new private Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        Vector2 veloctiy = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        rigidbody.MovePosition(rigidbody.position + veloctiy * Time.fixedDeltaTime * movementSpeed);
    }

    void InputControl() {
        if(Input.GetAxis("vertical") != 0) {

        }

        if(Input.GetAxis("horizontal") != 0) {

        }
    }
}
