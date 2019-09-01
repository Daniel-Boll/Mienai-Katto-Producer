using UnityEngine;
using System.Collections;

public class doggoMovement : MonoBehaviour {

    [SerializeField] float moveSpeed = .5f;
    [SerializeField] [Range(0.5f, 5f)] float minInterval;
    [SerializeField] [Range(0.5f, 5f)] float maxInterval;
    [SerializeField] int singleMovement;
    /*[SerializeField]*/ float interval = 0;
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;

    /*[SerializeField]*/ Vector2 movement;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        int dog_type = Random.Range(0, 2);
        anim.SetInteger("dog_type", dog_type);
    }

    // Update is called once per frame
    void Update () {
        interval -= Time.deltaTime;
        if (interval <= 0) {
            movement.x = Random.Range(-1.0f, 1.0f);
            movement.y = Random.Range(-1.0f, 1.0f);
            interval = Random.Range(minInterval, minInterval + maxInterval);
            if (movement.x > 0) {
                sr.flipX = true;
            } else {
                sr.flipX = false;
            }
        }
	}

    void FixedUpdate(){
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
