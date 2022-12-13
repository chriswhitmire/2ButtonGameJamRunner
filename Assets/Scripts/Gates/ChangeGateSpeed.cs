using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGateSpeed : MonoBehaviour
{
    
    [SerializeField] float speedMultiplier = 1.0f;
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            Debug.Log("collide");
            float newSpeed = GetComponent<GateMovement>().getSpeed() * speedMultiplier;
            Debug.Log("New Speed: " + newSpeed);
            
            GetComponent<GateMovement>().setSpeed(newSpeed);
            Debug.Log(other.gameObject.GetComponent<Player>().getSpeed());
        }    
    }
}
