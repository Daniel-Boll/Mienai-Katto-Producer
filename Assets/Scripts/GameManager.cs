using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int lastCorridor = 1;
    int startHealth = 0;
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject FullHeart;
    [SerializeField] GameObject EmptyHeart;
    [SerializeField] GameObject HaveKey;
    GameObject[] hearts;

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

    internal void updateHealth(int health) {
        //atualiza os corações na UI
        for(int i = 0;i< startHealth; i++) {
            float x = (i + 1) * 20 - 50;
            if (hearts[i] != null) {
                Destroy(hearts[i].gameObject);
                hearts[i] = null;
            }
            if (i < health) {
                hearts[i] = Instantiate<GameObject>( FullHeart, Vector3.zero, Quaternion.identity, canvas.transform);
            } else {
                hearts[i] = Instantiate<GameObject>(EmptyHeart, Vector3.zero, Quaternion.identity, canvas.transform);
            }
            hearts[i].transform.position = new Vector3(x, canvas.pixelRect.height+25, 0);

        }
    }

    public void UpdateHaveKey(bool haveKey) {
        if (HaveKey) {
            if (haveKey) {
                HaveKey.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            } else { 
                HaveKey.GetComponent<Image>().color = new Color(1, 1, 1, 0.25f);
            }
        }
    }

    public void SetStartHealth(int heart) {
        startHealth = heart;
        hearts = new GameObject[startHealth];
    }
}
