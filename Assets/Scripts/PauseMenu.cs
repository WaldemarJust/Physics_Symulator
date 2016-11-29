using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject MenuObject;

    // Use this for initialization
    void Start()
    {
        MenuObject.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                MenuObject.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                MenuObject.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void EndGame(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void ResumeGame()
    {
        MenuObject.SetActive(false);
        Time.timeScale = 1;
    }
}
