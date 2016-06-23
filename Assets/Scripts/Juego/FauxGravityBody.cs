using UnityEngine;
using System.Collections;

public class FauxGravityBody : MonoBehaviour {

    public FauxGravityAttractor attractor;
    private Transform myTransform;

	void Start () {
        GetComponent<Rigidbody>().useGravity = false;
        myTransform = transform;
	}
	
	
	void Update () {
        attractor.Attract(myTransform);
	}
}
