using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHorSpeed : MonoBehaviour
{
    
    [SerializeField] float speedMultiplier = 1.0f;
    [SerializeField] float maxSpeed = 10;
    [SerializeField] float minSpeed = 0.5f;
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            if(other.GetComponent<Player>().getSpeed() < maxSpeed && other.GetComponent<Player>().getSpeed() > minSpeed)
            {
                // Debug.Log("collide");
                float newSpeed = GetComponent<PlayerMovement>().getSpeed() * speedMultiplier;
                Debug.Log("New Speed: " + newSpeed);
                
                GetComponent<PlayerMovement>().setSpeed(newSpeed);
                Debug.Log(other.gameObject.GetComponent<Player>().getSpeed());

                setSpeedLimits(other);
            }
        }    
    }

    void setSpeedLimits(Collider2D other)
    {
        if(other.GetComponent<Player>().getSpeed() > maxSpeed)
        {
            other.GetComponent<Player>().setSpeed(maxSpeed);
        }
        else if(other.GetComponent<Player>().getSpeed() < minSpeed)
        {
            other.GetComponent<Player>().setSpeed(minSpeed);
        }
    }
}
