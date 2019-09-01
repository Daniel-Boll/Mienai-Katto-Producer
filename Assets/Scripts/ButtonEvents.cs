using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvents : MonoBehaviour
{
    int lastIndex = 1;

    void Start() {
        lastIndex = ((GameManager)GameObject.FindObjectOfType<GameManager>()).GetLastCorridor();
        Destroy(((GameManager)GameObject.FindObjectOfType<GameManager>()).gameObject);
    }

    public void StartEvent() {
        SceneManager.LoadScene(1);
    }

    public void ContinueEvent() {
        SceneManager.LoadScene(lastIndex);
    }

    public void ExitEvent() {
        Application.Quit();
    }
}
