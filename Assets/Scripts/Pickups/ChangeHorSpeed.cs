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

    [SerializeField] AudioClip speedUp;
    [SerializeField] AudioClip slowDown;

    AudioSource audioSource;
    
    private void Start() {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        Player player = p.GetComponentInChildren<Player>();
        maxSpeed = player.getMaxHorSpeed();
        minSpeed = player.getMinHorSpeed();

        d = GetComponent<DestroyPickup>();
        vFXManager = GetComponent<VFXManager>();
        audioSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();  
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            Debug.Log("hit");
            // Player playerScript = other.GetComponentInChildren<Player>();
            if(other.GetComponentInChildren<Player>().getHorSpeed() <= maxSpeed && other.GetComponentInChildren<Player>().getHorSpeed() >= minSpeed)
            {
                float newSpeed = other.GetComponentInChildren<Player>().getHorSpeed() * speedMultiplier;
                Debug.Log("New Speed: " + newSpeed);
                
                other.GetComponentInChildren<Player>().setHorSpeed(newSpeed);
                Debug.Log(other.gameObject.GetComponentInChildren<Player>().getHorSpeed());

                setSpeedLimits(other);
            }

            if(speedMultiplier > 1)
            {
                vFXManager.makeEffect(SpeedUpEffect, other.gameObject);
                audioSource?.PlayOneShot(speedUp);
            }
            else{
                vFXManager.makeEffect(SpeedDownEffect, other.gameObject);
                audioSource?.PlayOneShot(slowDown);
            }
            d.destroyPickup();
        }    
    }

    void setSpeedLimits(Collider2D other)
    {
        if(other.GetComponentInChildren<Player>().getHorSpeed() > maxSpeed)
        {
            other.GetComponentInChildren<Player>().setHorSpeed(maxSpeed);
        }
        else if(other.GetComponentInChildren<Player>().getHorSpeed() < minSpeed)
        {
            other.GetComponentInChildren<Player>().setHorSpeed(minSpeed);
        }
    }
}
