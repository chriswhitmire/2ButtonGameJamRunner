using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPickup : MonoBehaviour
{
    public void destroyPickup()
    {
        Destroy(this.gameObject);
    }
}
