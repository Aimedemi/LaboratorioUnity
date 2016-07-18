using UnityEngine;
using System.Collections;
using System;

public class DesktopPhysics : MonoBehaviour{
    public void moverse(Rigidbody rb, float speed)
    {
        //Vector3 pos = transform.position;
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveH, 0.0f, moveV);

        rb.AddForce(movement * speed);

    }
}