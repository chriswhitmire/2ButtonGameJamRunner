using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCheck : MonoBehaviour
{
    
    Player player;
    [SerializeField] GoalConditions goalConditions;
    [SerializeField] float delayToNextLevel = 2f;

    [SerializeField] AudioClip winSound;
    [SerializeField] AudioClip loseSound;

    AudioSource audioSource;

    [SerializeField] ParticleSystem winEffect;
    [SerializeField] ParticleSystem failEffect;
    VFXManager vFXManager;

    private void Start() 
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0].GetComponentInChildren<Player>();    
        vFXManager = GetComponent<VFXManager>();
        audioSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();  
    }

   private void OnTriggerEnter2D(Collider2D other) 
   {
        if (other.gameObject.tag == "Player")
        { 
            // Debug.Log("Collision registered");
            checkWinConditions(other);
        }
   }

    private void checkWinConditions(Collider2D other)
    {
        Debug.Log("Final Size: " + other.gameObject.GetComponentInChildren<Player>().getSize());
        Debug.Log("Final HorSpeed: " + other.gameObject.GetComponentInChildren<Player>().getHorSpeed());
        Debug.Log("Final VertSpeed: " + other.gameObject.GetComponentInChildren<Player>().getVertSpeed());
        if (checkPlayerSize() && checkPlayerVertSpeed() && checkPlayerHorSpeed() && checkIfScreenIsShaking())
        {
            
            Invoke("proceedToNextLevel", delayToNextLevel);

            audioSource?.PlayOneShot(winSound);
            Debug.Log("successsss");
            vFXManager.makeEffect(winEffect, other.gameObject);
        }
        else
        {
            Debug.Log("FAIL");
            vFXManager.makeEffect(failEffect, other.gameObject);
            audioSource?.PlayOneShot(loseSound);
            Invoke("reloadLevel", delayToNextLevel);
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

    bool checkIfScreenIsShaking()
    {
        return player.getShouldShake() == goalConditions.cameraIsShaking;
    }

}
