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
            // float transformPosition = (float)ply.transform.position.x;
            // Debug.Log(10-ply.transform.position.x);
            // Vector3 centerPos = Camera.main.ViewportToWorldPoint(new Vector3(.5f, 0.5f, distanceFromCamera));
            // ply.transform.position = centerPos;
            SceneManager.LoadScene(scene2);
        }
 }

}