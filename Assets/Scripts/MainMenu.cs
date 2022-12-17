using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start() 
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().PlayMusic();
    }

    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
