using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorScript : MonoBehaviour{

    public static doorScript Instace;
    public GameObject ply;
    string scene2 = "Scene2";
    float distanceFromCamera = 10f;
    
    void Awake(){
        if (Instace == null){
            Instace = this;
            DontDestroyOnLoad(ply);
        }else{
            Destroy(gameObject);
        }
    } 

    void OnTriggerEnter2D(Collider2D other){
        if (other.name == ply.name) {
            Debug.Log("Happening");
            SceneManager.LoadScene(scene2);
        }
 }

}