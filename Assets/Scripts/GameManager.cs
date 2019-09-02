using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int lastCorridor = 1;
    int startHealth = 0;
    [Header("Game Manager Configs")]
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject FullHeart;
    [SerializeField] GameObject EmptyHeart;
    [SerializeField] GameObject HaveKey;
    [SerializeField] Text TextTime;
    [SerializeField] GameObject vision1;
    [SerializeField] GameObject vision2;
    [SerializeField] GameObject vision3;

    [Header("Game Configs")]
    [SerializeField] float time = 300;//seconds

    GameObject[] hearts;

    void Awake() {
        int n = GameObject.FindObjectsOfType<GameManager>().Length;
        if (n == 1) {
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void setVision(){
        vision1.SetActive(true);
        vision2.SetActive(true);
        vision3.SetActive(true);
    }

    void Update() {
        time -= Time.deltaTime;
        TextTime.text = time.ToString("000.00");
    }

    public void SetLastCorridor(int index) {
        lastCorridor = index;
    }

    public int GetLastCorridor() {
        return lastCorridor;
    }

    public void updateTimer(float increase){
        time += increase;
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
