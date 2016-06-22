using UnityEngine;
using System.Collections;

public class Bouncer : MonoBehaviour
{

    Rigidbody myRigidbody;
    Vector3 oldVel;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        oldVel = myRigidbody.velocity;
    }

    void OnCollisionEnter(Collision c)
    {
        ContactPoint cp = c.contacts[0];
        // calculate with addition of normal vector
        // myRigidbody.velocity = oldVel + cp.normal*2.0f*oldVel.magnitude;

        // calculate with Vector3.Reflect
        myRigidbody.velocity = Vector3.Reflect(oldVel, cp.normal);
        

        // bumper effect to speed up ball
        myRigidbody.velocity += cp.normal * 2.0f;
    }
}