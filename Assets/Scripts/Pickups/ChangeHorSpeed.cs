using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHorSpeed : MonoBehaviour
{
    
    [SerializeField] float speedMultiplier = 1.0f;
    float maxSpeed = 10;
    float minSpeed = 0.5f;

    DestroyPickup d;
    [SerializeField] ParticleSystem SpeedUpEffect;
    [SerializeField] ParticleSystem SpeedDownEffect;
    VFXManager vFXManager;
    
    private void Start() {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        Player player = p.GetComponent<Player>();
        maxSpeed = player.getMaxHorSpeed();
        minSpeed = player.getMinHorSpeed();

        d = GetComponent<DestroyPickup>();
        vFXManager = GetComponent<VFXManager>();
    }

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

            if(speedMultiplier > 1)
            {
                vFXManager.makeEffect(SpeedUpEffect, other.gameObject);
            }
            else{
                vFXManager.makeEffect(SpeedDownEffect, other.gameObject);
            }
            d.destroyPickup();
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
