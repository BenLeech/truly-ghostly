using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float movementSpeed = 1f;
    new private Rigidbody2D rigidbody;
    private Vector2 velocity = new Vector2();
    private bool isMovingToPosition = false;

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
        StartCoroutine("DoMoveToPosition", position);
    }

    public bool GetIsMovingToPosition() {
        return isMovingToPosition;
    }

    IEnumerator DoMoveToPosition(Vector2 position) {
        isMovingToPosition = true;
        float t = 0;
        float step = (movementSpeed / ((Vector2)gameObject.transform.position - position).magnitude) * Time.fixedDeltaTime;
        while(t <= 1.0f) {
            Vector2 lerpPosition = Vector2.Lerp(gameObject.transform.position, position, t);
            t += step;
            gameObject.transform.position = lerpPosition;
            yield return new WaitForFixedUpdate();
        }
        gameObject.transform.position = position;
        isMovingToPosition = false;
    }

}
