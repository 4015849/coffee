using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused;
    public GameObject optionsMenu;
    public GameObject keybindingsMenu;
    public GameObject volumeMenu;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (keybindingsMenu.activeSelf == enabled || volumeMenu.activeSelf == enabled)
            {
                keybindingsMenu.SetActive(false);
                volumeMenu.SetActive(false);
            }
            else if (optionsMenu.activeSelf == enabled)
            {
                optionsMenu.SetActive(false);
            }
            else if (isPaused)
            {
                Continue();
            }
            else
            {
                pauseGame();
            }
        }
    }

    public void pauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }
    public void Continue()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
