using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class StopScreenShake : MonoBehaviour
{
    
    DestroyPickup d;
    [SerializeField] ParticleSystem startingScreenShakeEffect;
    [SerializeField] ParticleSystem stoppingScreenShakeEffect;
    VFXManager vFXManager;

    private void Start() {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        Player player = p.GetComponentInChildren<Player>();

        d = GetComponent<DestroyPickup>();
        vFXManager = GetComponent<VFXManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            Debug.Log("hit");

            other.GetComponentInChildren<Player>().setShouldShake(false);


            if(other.GetComponentInChildren<Player>().getShouldShake())
            {
                vFXManager.makeEffect(startingScreenShakeEffect, other.gameObject);
            }
            else{
                vFXManager.makeEffect(stoppingScreenShakeEffect, other.gameObject);
            }
            d.destroyPickup();
        }    
    }

}
