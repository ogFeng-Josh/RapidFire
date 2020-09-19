using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement01 : MonoBehaviour
{
    public int moveSpeed = 3;
    public Rigidbody2D rb1;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    void Update(){

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate(){

        rb1.MovePosition(rb1.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb1.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        rb1.rotation = angle;
    }
}
