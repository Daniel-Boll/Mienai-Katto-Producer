﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class playerMovement : MonoBehaviour {

    public float moveSpeed = 5f;
    [SerializeField] GameObject music;
    public Rigidbody2D rb;
    Animator animator;
    Vector2 movement;
    public bool haveKey = false;
    public int heart = 3;
    private int maxHeart = 0;
    public bool vision = false;
    SpriteRenderer falaSR;
    SpriteRenderer sr;
    float falaCooldown = 0f;
    GameManager gm;
    bool invencivel = false;
    float invencivelCoolDown = 1f;

    void Awake(){
        int n = GameObject.FindGameObjectsWithTag("Player").Length;
        int n_m = GameObject.FindGameObjectsWithTag("Music").Length;

        if (n == 1){
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
        
        if (n_m == 1){
            DontDestroyOnLoad(music);
        }else{
            Destroy(music);
        }
    } 

    void Start() {
        animator = GetComponent<Animator>();
        falaSR = transform.Find("Fala").GetComponentInChildren<SpriteRenderer>();
        sr = GetComponent<SpriteRenderer>();
        gm = GameObject.FindObjectOfType<GameManager>();
        gm.SetStartHealth(heart);
        gm.updateHealth(heart);
        maxHeart = heart;
    }

	// Update is called once per frame
	void Update () {
		float moveX = Input.GetAxisRaw("Horizontal");
	        float moveY = Input.GetAxisRaw("Vertical");
	
	        //05.08.2024 - Thiago: Corrige o erro que duplica o movespeed ao clicar em dois botões ao mesmo tempo.
	        movement = new Vector2(moveX, moveY).normalized; // Normaliza o vetor de movimento
	
	        if(moveX == 1){
	            animator.SetInteger("direction", 2);
	        }else if(moveX == -1){
	            animator.SetInteger("direction", 3);
	        }else if(moveY == 1){
	            animator.SetInteger("direction", 1);
	        }else if(moveY == -1){
	            animator.SetInteger("direction", 0);
	        }else {
	            animator.SetInteger("direction", 4);
	        }
        
        if(heart == 0) {
            gm.SetLastCorridor(SceneManager.GetActiveScene().buildIndex);
            heart = 3;
            gm.updateHealth(heart);
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

        if (invencivel) {
            invencivelCoolDown -= Time.deltaTime;
        }
        if (invencivelCoolDown <= 0) { 
            invencivel = false;
            invencivelCoolDown = 1f;
            sr.color = new Color(1, 1, 1, 1);
        }
	}
    
    public void curarVida(){
        heart = maxHeart;
        gm.updateHealth(heart);
    }

    public void GetVision(){
        gm.setVision();
    }

    public void causarDano() {
        if (!invencivel) {
            heart--;
            gm.updateHealth(heart);
            invencivel = true;
            sr.color = new Color(1, 0.2f, 0.2f, 0.8f);
        }
    }

    public void increaseTimer(){
        gm.updateTimer(30f);        
    }

    public void GetKey() {
        GetKey(true);
    }

    public void GetKey(bool key) {
        haveKey = key;
        gm.UpdateHaveKey(haveKey);
    }
    
    void FixedUpdate(){
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
