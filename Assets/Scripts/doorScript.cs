using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorScript : MonoBehaviour{

    public static doorScript Instace;
    public GameObject ply;
    string scene2 = "Scene2";
    float distanceFromCamera = 10f;
    
    void Start(){
        ply = GameObject.FindGameObjectWithTag("Player");
    }

    void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.name == ply.name) {
            if(other.gameObject.GetComponent<playerMovement>().haveKey){
                SceneManager.LoadScene(scene2);
                other.gameObject.GetComponent<playerMovement>().haveKey = false;
            }
        }
 }

}