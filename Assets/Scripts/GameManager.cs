using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int lastCorridor = 1;

    void Awake() {
        int n = GameObject.FindObjectsOfType<GameManager>().Length;
        if (n == 1) {
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
    
    public void SetLastCorridor(int index) {
        lastCorridor = index;
    }

    public int GetLastCorridor() {
        return lastCorridor;
    }

}
