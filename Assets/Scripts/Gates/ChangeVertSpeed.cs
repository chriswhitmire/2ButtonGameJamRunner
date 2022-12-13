using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVertSpeed : MonoBehaviour
{
    
    [SerializeField] float speedMultiplier = 1.0f;
    float maxSpeed = 10;
    float minSpeed = 0.5f;
    
    private void Start() {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        Player player = p.GetComponent<Player>();
        maxSpeed = player.getMaxVertSpeed();
        minSpeed = player.getMinVertSpeed();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            // Debug.Log("collide");
            float newSpeed = other.gameObject.GetComponent<Player>().getVertSpeed() * speedMultiplier;
            Debug.Log("New Player Speed: " + newSpeed);
            other.gameObject.GetComponent<Player>().setVertSpeed(newSpeed);
        }    
    }
}
