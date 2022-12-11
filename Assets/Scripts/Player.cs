using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    Vector2 movement;
    [SerializeField] float speed = 1;
    
    // for later
    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveDir = Input.GetAxisRaw("Vertical");

        Vector3 moveVector = new Vector3(0, moveDir*speed*Time.fixedDeltaTime);

        transform.position += moveVector;

        // for later
        // animator.SetFloat("VerticalSpeed", movement.y);
        // animator.SetFloat("Speed", movement.sqrMagnitude);
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
