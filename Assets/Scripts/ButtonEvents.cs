using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvents : MonoBehaviour
{
    public void StartEvent() {
        SceneManager.LoadScene(1);
    }

    public void ContinueEvent() {
        SceneManager.LoadScene(1);
    }

    public void ExitEvent() {
        Application.Quit();
    }
}
