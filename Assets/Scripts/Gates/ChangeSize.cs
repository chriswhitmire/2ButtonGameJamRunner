using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSize : MonoBehaviour
{
    
    [SerializeField] float sizeMultiplier = 1.0f;
    
    [SerializeField] float maxSize = 4;
    [SerializeField] float minSize = 0.5f;
    [SerializeField] bool hasChangedSize = false;
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        // Vector3 localScale = other.gameObject.transform.localScale;
        if (other.tag == "Player" && !hasChangedSize)
        {
            if(other.gameObject.transform.localScale.x < maxSize && other.gameObject.transform.localScale.x > minSize)
            {
                other.gameObject.transform.localScale *= sizeMultiplier;

                hasChangedSize = true;
                Debug.Log("ChangedSize");
                Invoke("reset", 1);
            }
            
        }    
    }

    void reset()
    {
        hasChangedSize = false;
    }
}
