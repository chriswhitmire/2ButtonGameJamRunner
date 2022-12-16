using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSize : MonoBehaviour
{
    
    [SerializeField] float sizeMultiplier = 1.0f;
    float maxSize;
    float minSize;

    DestroyPickup d;
    [SerializeField] ParticleSystem sizeUpEffect;
    [SerializeField] ParticleSystem sizeDownEffect;
    VFXManager vFXManager;

    private void Start() {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        Player player = p.GetComponentInChildren<Player>();
        maxSize = player.getMaxSize();
        minSize = player.getMinSize();

        d = GetComponent<DestroyPickup>();
        vFXManager = GetComponent<VFXManager>();
    }
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        // Vector3 localScale = other.gameObject.transform.localScale;
        if (other.tag == "Player")
        {
            if(other.GetComponentInChildren<Player>().getSize() <= maxSize && other.GetComponentInChildren<Player>().getSize() >= minSize)
            {
                float curSize = other.GetComponentInChildren<Player>().getSize();
                Debug.Log(curSize);
                float newSize = curSize * sizeMultiplier;
                other.gameObject.transform.localScale = new Vector3(newSize, newSize, newSize);//*= sizeMultiplier;

                other.GetComponentInChildren<Player>().setSize(newSize);

                setSizeLimits(other);

                Debug.Log("ChangedSize");
            }

            if(sizeMultiplier > 1)
            {
                vFXManager.makeEffect(sizeUpEffect, other.gameObject);
            }
            else{
                vFXManager.makeEffect(sizeDownEffect, other.gameObject);
            }
            d.destroyPickup();
        }    
    }

    void setSizeLimits(Collider2D other)
    {
        if(other.GetComponentInChildren<Player>().getSize() > maxSize)
        {
            other.GetComponentInChildren<Player>().setSize(maxSize);
        }
        else if(other.GetComponentInChildren<Player>().getSize() < minSize)
        {
            other.GetComponentInChildren<Player>().setSize(minSize);
        }
    }

    
}
