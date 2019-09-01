using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class playerMovement : MonoBehaviour {

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Animator animator;
    Vector2 movement;
    public bool haveKey = false;
    public int heart = 3;
    private int maxHeart = 0;
    public bool vision = false;
    SpriteRenderer falaSR;
    float falaCooldown = 0f;

    void Awake(){
        int n = GameObject.FindGameObjectsWithTag("Player").Length;
        if (n == 1){
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    } 

    void Start(){
        animator = GetComponent<Animator>();
        falaSR = transform.Find("Fala").GetComponentInChildren<SpriteRenderer>();
        GameObject.FindObjectOfType<GameManager>().SetStartHealth(heart);
        GameObject.FindObjectOfType<GameManager>().updateHealth(heart);
        maxHeart = heart;
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
        
        if(heart == 0){
            GameObject.FindObjectOfType<GameManager>().SetLastCorridor(SceneManager.GetActiveScene().buildIndex);
            heart = 3;
            GameObject.FindObjectOfType<GameManager>().updateHealth(heart);
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }

        if (Input.GetKeyDown(KeyCode.Space) && falaCooldown<=0) {
            falaCooldown = 0.8f;
            //ver os alunos que estão por perto
            AlunoMovement[] alunos = GameObject.FindObjectsOfType<AlunoMovement>();
            foreach (AlunoMovement aluno in alunos) {
                if (aluno.IsCloseEnought()) {
                    aluno.GradeRegected();
                }
            }
        }
        if (falaCooldown > 0) {
            falaCooldown -= Time.deltaTime;
            falaSR.color = new Color(1, 1, 1, 1);
        } else {
            falaSR.color = new Color(1, 1, 1, 0);
        }
	}

    public void causarDano() {
        heart--;
        GameObject.FindObjectOfType<GameManager>().updateHealth(heart);
    }

    public void curarVida(){
        heart = maxHeart;
        GameObject.FindObjectOfType<GameManager>().updateHealth(heart);
    }

    void FixedUpdate(){
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
