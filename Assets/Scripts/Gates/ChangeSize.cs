using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSize : MonoBehaviour
{
    
    [SerializeField] float sizeMultiplier = 1.0f;
    
    bool hasChangedSize = false;
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player" && !hasChangedSize)
        {
            other.gameObject.transform.localScale *= sizeMultiplier;

            hasChangedSize = true;
            Debug.Log("ChangedSize");
        }    
    }
}
