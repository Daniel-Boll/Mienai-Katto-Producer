using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Animator animator;
    Vector2 movement;

    void Start(){
        animator = GetComponent<Animator>();
    }

	// Update is called once per frame
	void Update () {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(movement.x == 1){
            animator.SetInteger("direction", 2);
        }else
        if(movement.x == -1){
            animator.SetInteger("direction", 3);
        }else
        if(movement.y == 1){
            animator.SetInteger("direction", 1);
        }else
        if(movement.y == -1){
            animator.SetInteger("direction", 0);
        }else {
            animator.SetInteger("direction", 4);
        }

	}

    void FixedUpdate(){
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
     }
}
