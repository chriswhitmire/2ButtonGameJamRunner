using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCheck : MonoBehaviour
{
    
    Player player;
    [SerializeField] GoalConditions goalConditions;
    [SerializeField] float delayToNextLevel = 2f;
    
    private void Start() 
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Player>();    
    }

   private void OnTriggerEnter2D(Collider2D other) 
   {
        if (other.gameObject.tag == "Player")
        { 
            Debug.Log("Collision registered");
            checkWinConditions();
        }
   }

 

    private void checkWinConditions()
    {
        if (checkPlayerSize() && checkPlayerVertSpeed() && checkPlayerHorSpeed())
        {
            
            Invoke("proceedToNextLevel", delayToNextLevel);
            Debug.Log("successsss");
        }

        else
        {
            Invoke("reloadLevel", delayToNextLevel);
            Debug.Log("fail");
        }
    }

    private void proceedToNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex+1);
    }

    private void reloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }


    bool checkPlayerSize()
    {
        return isInRange(player.getSize(), goalConditions.minPlayerSize, goalConditions.maxPlayerSize);
    }

    bool checkPlayerVertSpeed()
    {
        return isInRange(player.getVertSpeed(), goalConditions.minPlayerVertSpeed, goalConditions.maxPlayerVertSpeed);
    }

    bool checkPlayerHorSpeed()
    {
        return isInRange(player.getHorSpeed(), goalConditions.minPlayerHoriSpeed, goalConditions.maxPlayerHoriSpeed);
    }

    bool isInRange(float val, float min, float max)
    {
        if (val >= min && val <= max)
        {
            return true;
        }

        return false;
    }
}
