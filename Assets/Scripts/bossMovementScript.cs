using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossMovementScript : MonoBehaviour {

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float closeEnought = .6f;
    [SerializeField] float distance;
    [SerializeField] float angle = 0;
    private Transform profTransform;
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer falaSR;
    /*[SerializeField]*/

    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        profTransform = GameObject.FindGameObjectWithTag("Player").transform;
        falaSR = transform.Find("Fala").GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
    }

    void FixedUpdate() {
        Movement();

        //Animations
        // angle = Vector2.SignedAngle(transform.position, profTransform.position);
        // if (gibeNota) {
        //     if (angle >= -45f && angle <= 45f) {//para baixo
        //         animator.Play("aluno_front_walk");
        //     }
        //     if (angle > 45f && angle <= 135f) {//para baixo
        //         animator.Play("aluno_right_walk");
        //     }
        //     if (angle > 135f || angle < -135f) {//para baixo
        //         animator.Play("aluno_back_walk");
        //     }
        //     if (angle < -45f && angle >= -135f) {//para baixo
        //         animator.Play("aluno_left_walk");
        //     }
        // }
        // if (!gibeNota) {
        //     if (angle >= -45f && angle <= 45f) {//para baixo
        //         animator.Play("aluno_front_stand");
        //     }
        //     if (angle > 45f && angle <= 135f) {//para baixo
        //         animator.Play("aluno_right_stand");
        //     }
        //     if (angle > 135f || angle < -135f) {//para baixo
        //         animator.Play("aluno_back_stand");
        //     }
        //     if (angle < -45f && angle >= -135f) {//para baixo
        //         animator.Play("aluno_left_stand");
        //     }
        // }
    }

    private void Movement() {
        distance = Vector2.Distance(transform.position, profTransform.position);
        if (distance > closeEnought) {
            rb.MovePosition(Vector2.MoveTowards(transform.position,
                profTransform.position,
                moveSpeed * Time.fixedDeltaTime));
            falaSR.color = new Color(1, 1, 1, 0);
        }
        if (distance <= closeEnought) {
            falaSR.color = new Color(1, 1, 1, 1);
        }
    }

    public bool IsCloseEnought() {
        return (closeEnought> distance? true: false);
    }
}