using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorScript : MonoBehaviour{

    public static doorScript Instace;
    public GameObject ply;
    [SerializeField] string scene = "Scene2";
    [SerializeField] bool needKey = true;
    float distanceFromCamera = 10f;
    
    void Start(){
        ply = GameObject.FindGameObjectWithTag("Player");
    }

    void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.name == ply.name) {
            if(needKey){
                if(other.gameObject.GetComponent<playerMovement>().haveKey){
                    SceneManager.LoadScene(scene);
                    other.gameObject.GetComponent<playerMovement>().haveKey = false;
                }
            }else{
                 SceneManager.LoadScene(scene);
            }
        }  
    }
}