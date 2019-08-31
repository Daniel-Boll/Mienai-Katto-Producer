using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemScript : MonoBehaviour{

    public static itemScript Instace;
    public GameObject ply;
    float distanceFromCamera = 10f;
    // public Text text;
    public Collider2D door_collider;
    
    void Awake(){
        if (Instace == null){
            Instace = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(ply);
        }else{
        }
    }


    void OnTriggerEnter2D(Collider2D other){
        if (other.name == "Character") {
            Debug.Log("Pegando item");
            // text.text = "Item has been collected";
            door_collider.isTrigger = true;
            Destroy(gameObject);
        }
    }

}