using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ocultRoom : MonoBehaviour{

    public static ocultRoom Instace;
    public GameObject ply;
    public string scene = "Scene1.5";
    float distanceFromCamera = 10f;
    

    void Start(){
        ply = GameObject.FindGameObjectWithTag("Player");
    }

    void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.name == ply.gameObject.name) {
            SceneManager.LoadScene(scene);
        }
    }

}