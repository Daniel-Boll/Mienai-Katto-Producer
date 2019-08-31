using UnityEngine;
using System.Collections;

public class doggoMovement : MonoBehaviour {

    public float moveSpeed = .5f;
    public Rigidbody2D rb;

    Vector2 movement;

	// Update is called once per frame
	void Update () {
        movement.x =  Random.Range (-1.0f, 1.0f);
        // createRoutine
        movement.y =  Random.Range (-1.0f, .0f);
	}

    void FixedUpdate(){
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
     }
}
