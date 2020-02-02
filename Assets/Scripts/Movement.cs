using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DIRECTION {
    UP = 0,
    LEFT = 1,
    RIGHT = 2,
    DOWN = 3
}

public class Movement : MonoBehaviour {

    public float movementSpeed = 1f;
    new private Rigidbody2D rigidbody;
    private Vector2 velocity = new Vector2();
    private bool isMovingToPosition = false;

    private DialogManager dialogManager;

    private Animator ani;

    public void Awake() {
        dialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();
        ani = GetComponent<Animator>();
    }

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
            if(ani != null) {
                Debug.Log("set direction: " + determineDirection((Vector2)gameObject.transform.position, position));
                ani.SetInteger("direction", determineDirection((Vector2)gameObject.transform.position, position));
            }
            float step = ((movementSpeed / 100) / ((Vector2)gameObject.transform.position - position).magnitude) * Time.fixedDeltaTime;
            while(t <= 1.0f) {
                if (!dialogManager.isInDialog) {
                    Vector2 lerpPosition = Vector2.Lerp(gameObject.transform.position, position, t);
                    t += step;
                    gameObject.transform.position = lerpPosition;
                } else {
                    step = 0;
                }
                yield return new WaitForFixedUpdate();
            }
            gameObject.transform.position = position;
            isMovingToPosition = false;
    }

    private int determineDirection(Vector2 startPos, Vector2 endPos) {
        if(endPos.x - startPos.x > 0){
            return 0;
        } else if(endPos.y - startPos.y > 0) {
            return 1;
        } else if(endPos.x - startPos.x < 0) {
            return 2;
        } else  {
            return 3;
        }
        
    }

}
