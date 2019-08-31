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

    void OnTriggerEnter2D(Collider2D other){
        if (other.name == "Character") {
            Debug.Log("Pegando item");
            other.GetComponent<playerMovement>().haveKey = true;
            Destroy(gameObject);
        }
    }

}