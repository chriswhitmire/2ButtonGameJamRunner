using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSize : MonoBehaviour
{
    
    [SerializeField] float sizeMultiplier = 1.0f;
    float maxSize;
    float minSize;
    [SerializeField] bool hasChangedSize = false;

    private void Start() {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        Player player = p.GetComponent<Player>();
        maxSize = player.getMaxSize();
        minSize = player.getMinSize();
    }
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        // Vector3 localScale = other.gameObject.transform.localScale;
        if (other.tag == "Player" && !hasChangedSize)
        {
            if(other.gameObject.transform.localScale.x < maxSize && other.gameObject.transform.localScale.x > minSize)
            {
                other.gameObject.transform.localScale *= sizeMultiplier;

                other.gameObject.GetComponent<Player>().setSize(other.gameObject.GetComponent<Player>().getSize()*sizeMultiplier);

                setSizeLimits(other);

                hasChangedSize = true;
                Debug.Log("ChangedSize");
                Invoke("reset", 1);
            }
        }    
    }

    void setSizeLimits(Collider2D other)
    {
        if(other.gameObject.transform.localScale.x > maxSize)
        {
            other.gameObject.transform.localScale = new Vector3(maxSize,maxSize,maxSize);
        }
        else if(other.gameObject.transform.localScale.x < 0.5f)
        {
            other.gameObject.transform.localScale = new Vector3(minSize,minSize,minSize);
        }
    }

    void reset()
    {
        hasChangedSize = false;
    }
}
