using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb;
    [SerializeField] float speed = 1;


    private void Start() 
    {
        rb = this.GetComponent<Rigidbody2D>(); 
    }

   private void FixedUpdate() 
   {
        Vector3 moveVector = new Vector3(speed*Time.deltaTime, 0);

        this.transform.position += moveVector;
   }

   public float getSpeed()
   {
        return speed; 
   }

   public void setSpeed(float newSpeed)
   {
        speed = newSpeed;
   }
}
