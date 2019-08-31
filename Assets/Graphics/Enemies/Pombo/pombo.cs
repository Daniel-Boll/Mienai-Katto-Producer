using UnityEngine;
using System.Collections;

public class pombo : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public GameObject bird;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(bird.transform.position.x);
        float birdPosition = bird.transform.position.x;
        if (birdPosition < -11.72) {

            transform.position  = new Vector3(11.15f, -0.07f);

        }
        movimentoSexual();
    }
    void movimentoSexual()
    {
        movement.x = -1;
        movement.y = 0;
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}