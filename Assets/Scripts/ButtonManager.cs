using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void start(string scene)
    {
        CountDown.play = false;
        SceneManager.LoadScene(scene);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void EndGame(string scene)
    {
        SceneManager.LoadScene(scene);
    }
	
}
