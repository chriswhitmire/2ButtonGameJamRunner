using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 movement;
    [SerializeField] float horSpeed = 1;
    [SerializeField] float vertSpeed = 1;
    [SerializeField] float size = 1;

    [SerializeField] float maxHorSpeed = 10;
    [SerializeField] float minHorSpeed = 0.5f;
    [SerializeField] float maxVertSpeed = 10;
    [SerializeField] float minVertSpeed = 0.5f;
    [SerializeField] float maxSize = 4;
    [SerializeField] float minSize = 0.5f;
    
    // for later
    Animator animator;
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        float moveUpDir = Input.GetAxisRaw("Vertical");

        Vector3 moveUpVector = new Vector3(0, moveUpDir * vertSpeed * Time.fixedDeltaTime);

        transform.position += moveUpVector;
        // for later
        // animator.SetFloat("VerticalSpeed", movement.y);
        // animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate() 
    {
        Vector3 moveDownVector = new Vector3(horSpeed * Time.deltaTime, 0);

        this.transform.position += moveDownVector;
    }

    public float getHorSpeed()
    {
        return horSpeed;
    }
    public float getVertSpeed()
    {
        return vertSpeed;
    }
    public float getSize()
    {
        return size;
    }
    public void setHorSpeed(float newSpeed)
    {
        horSpeed = newSpeed;
    }
    public void setVertSpeed(float newSpeed)
    {
        vertSpeed = newSpeed;
    }
    public void setSize(float newSize)
    {
        size = newSize;
    }
}
