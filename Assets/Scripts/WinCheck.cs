using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCheck : MonoBehaviour
{
    
    Player player;
    [SerializeField] GoalConditions goalConditions;
    [SerializeField] ParticleSystem winEffect;
    [SerializeField] ParticleSystem failEffect;
    VFXManager vFXManager;

    private void Start() 
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Player>();    
        vFXManager = GetComponent<VFXManager>();
    }

   private void OnTriggerEnter2D(Collider2D other) 
   {
        if (other.gameObject.tag == "Player")
        { 
            Debug.Log("Collision registered");
            checkWinConditions(other);
        }
   }

    private void checkWinConditions(Collider2D other)
    {
        if (checkPlayerSize() && checkPlayerVertSpeed() && checkPlayerHorSpeed())
        {
            // go to next scene
            Debug.Log("successsss");
            vFXManager.makeEffect(winEffect, other.gameObject);
        }
        else
        {
            Debug.Log("FAIL");
            vFXManager.makeEffect(failEffect, other.gameObject);
        }
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
