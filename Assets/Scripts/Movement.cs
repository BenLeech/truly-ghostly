using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float movementSpeed = 1f;
    new private Rigidbody2D rigidbody;
    private Vector2 velocity = new Vector2();

    void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        rigidbody.MovePosition(rigidbody.position + velocity * Time.fixedDeltaTime * movementSpeed);
    }

    public void SetMovementVelocity(float x, float y) {
        velocity = new Vector2(x,y);
    }

    public void MoveToPosition(Vector2 position) {

    }

}
