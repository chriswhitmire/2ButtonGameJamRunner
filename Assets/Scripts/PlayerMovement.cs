using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

//     Rigidbody2D rb;
    Player player;
//     float horSpeed;
//     float vertSpeed;

     private void Start() 
     {
          player = GetComponentInChildren<Player>();
          // horSpeed = player.getHorSpeed();
          // vertSpeed = player.getVertSpeed();
          // rb = this.GetComponent<Rigidbody2D>(); 
     }

     private void Update() 
     {
          float moveUpDir = Input.GetAxisRaw("Vertical");

          Vector3 moveUpVector = new Vector3(0, moveUpDir * player.getVertSpeed() * Time.fixedDeltaTime);

          transform.position += moveUpVector;
     }

     private void FixedUpdate() 
     {
        Vector3 moveDownVector = new Vector3(player.getHorSpeed() * Time.deltaTime, 0);

        this.transform.position += moveDownVector;

        float clampedY = Mathf.Clamp(this.transform.position.y, -3, 3);

        this.transform.position = new Vector3(this.transform.position.x, clampedY, this.transform.position.z);
     }
}
