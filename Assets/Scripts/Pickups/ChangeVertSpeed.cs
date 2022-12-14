using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVertSpeed : MonoBehaviour
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
        maxSpeed = player.getMaxVertSpeed();
        minSpeed = player.getMinVertSpeed();
        
        d = GetComponent<DestroyPickup>();
        vFXManager = GetComponent<VFXManager>();
        audioSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();  
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            // Debug.Log("collide");
            float newSpeed = other.gameObject.GetComponentInChildren<Player>().getVertSpeed() * speedMultiplier;
            Debug.Log("New Player Speed: " + newSpeed);
            other.gameObject.GetComponentInChildren<Player>().setVertSpeed(newSpeed);    
        
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
}
