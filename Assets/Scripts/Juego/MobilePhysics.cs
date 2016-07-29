using UnityEngine;
using System.Collections;
using System;

public class MobilePhysics : MonoBehaviour{
    public void moverse(Rigidbody rb, float speed)
    {
        speed = speed * 50;
        float moveH = Input.acceleration.x;
        float moveV = Input.acceleration.y;
		float moveA = 0.0f;

		if ((Input.touchCount == 1) && (Input.GetTouch (0).phase == TouchPhase.Began)) {
			moveA = 8.0f;
		}
		Vector3 movement = new Vector3(moveH, moveA, moveV);

		rb.AddForce(rb.transform.TransformDirection(movement) * speed * Time.deltaTime);

    }
}