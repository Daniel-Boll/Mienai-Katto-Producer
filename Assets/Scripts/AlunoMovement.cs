using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlunoMovement : MonoBehaviour {

    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float closeEnought = .6f;
    [SerializeField] float distance;
    [SerializeField] bool gibeNota = true;
    private Transform profTransform;
    Rigidbody2D rb;
    SpriteRenderer falaSR;
    /*[SerializeField]*/

    // Start is called before the first frame update
    void Start()
    {
        profTransform = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        falaSR = transform.Find("Fala").GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
    }

    void FixedUpdate() {
        distance = Vector2.Distance(transform.position, profTransform.position);
        if (distance > closeEnought && gibeNota) {
            rb.MovePosition(Vector2.MoveTowards(transform.position,
                profTransform.position,
                moveSpeed * Time.fixedDeltaTime));
            falaSR.color = new Color(1, 1, 1, 0);
        }
        if (distance <= closeEnought) {
            falaSR.color = new Color(1, 1, 1, 1);
        }
    }

    public void GradeRegected() {
        gibeNota = false;
    }
}
