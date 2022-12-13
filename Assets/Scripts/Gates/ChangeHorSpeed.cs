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
            if(other.GetComponent<Player>().getHorSpeed() < maxSpeed && other.GetComponent<Player>().getHorSpeed() > minSpeed)
            {
                // Debug.Log("collide");
                float newSpeed = other.GetComponent<Player>().getHorSpeed() * speedMultiplier;
                Debug.Log("New Speed: " + newSpeed);
                
                other.GetComponent<Player>().setHorSpeed(newSpeed);
                Debug.Log(other.gameObject.GetComponent<Player>().getHorSpeed());

                setSpeedLimits(other);
            }
        }    
    }

    void setSpeedLimits(Collider2D other)
    {
        if(other.GetComponent<Player>().getHorSpeed() > maxSpeed)
        {
            other.GetComponent<Player>().setHorSpeed(maxSpeed);
        }
        else if(other.GetComponent<Player>().getHorSpeed() < minSpeed)
        {
            other.GetComponent<Player>().setHorSpeed(minSpeed);
        }
    }
}
