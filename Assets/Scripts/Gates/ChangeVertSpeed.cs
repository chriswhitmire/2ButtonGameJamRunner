using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVertSpeed : MonoBehaviour
{
    
    [SerializeField] float speedMultiplier = 1.0f;
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            // Debug.Log("collide");
            float newSpeed = other.gameObject.GetComponent<Player>().getSpeed() * speedMultiplier;
            Debug.Log("New Player Speed: " + newSpeed);
            other.gameObject.GetComponent<Player>().setSpeed(newSpeed);
        }    
    }
}
