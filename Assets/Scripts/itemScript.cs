﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemScript : MonoBehaviour{

    public static itemScript Instace;
    public GameObject ply;
    [SerializeField] string which = "key";
    float distanceFromCamera = 10f;
    // public Text text;
    // public Collider2D door_collider;

    void OnTriggerEnter2D(Collider2D other){
        if (other.name == "Character") {
            Debug.Log("Pegando item");
            if(which == "key") other.GetComponent<playerMovement>().haveKey = true;
            if(which == "eye") other.GetComponent<playerMovement>().vision = true;
            if(which == "time"){
                // insert time
            }
            if(which == "life") {
                other.GetComponent<playerMovement>().curarVida();
            }
            
            Destroy(gameObject);
        }
    }

}