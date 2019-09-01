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
            if(other.gameObject.GetComponent<playerMovement>().haveKey && needKey){
                SceneManager.LoadScene(scene);
                Debug.Log("Do destroying key");
                other.gameObject.GetComponent<playerMovement>().haveKey = false;
            }else{
                Debug.Log("Not destroying key");
                SceneManager.LoadScene(scene);
            }
        }
 }

}