using UnityEngine;
using System.Collections;
using System;

public class MobilePhysics : MonoBehaviour{
    public void moverse(Rigidbody rb, float speed)
    {
        speed = speed * 10;
        float moveH = Input.acceleration.x;
        float moveV = Input.acceleration.y;

        Vector3 movement = new Vector3(moveH, 0.0f, moveV);

        rb.AddForce(movement * speed * Time.deltaTime);

    }
}