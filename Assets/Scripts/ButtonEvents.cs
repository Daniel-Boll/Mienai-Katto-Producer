using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvents : MonoBehaviour
{
    int lastIndex = 1;


    public void StartEvent() {
        SceneManager.LoadScene(1);
    }

    public void ContinueEvent() {
        lastIndex = ((GameManager)GameObject.FindObjectOfType<GameManager>()).GetLastCorridor();
        SceneManager.LoadScene(lastIndex);
    }

    public void ExitEvent() {
        Application.Quit();
    }
}
