using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    static bool isPaused = false;
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] GameObject gameUI;

    private void Start() {
        pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }

    public void resume()
    {
        pauseMenuUI.SetActive(false);
        gameUI.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void pause()
    {
        pauseMenuUI.SetActive(true);
        gameUI.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void restart()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        resume();
    }

    public void toMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public bool getIsPaused()
    {
        return isPaused;
    }
}
