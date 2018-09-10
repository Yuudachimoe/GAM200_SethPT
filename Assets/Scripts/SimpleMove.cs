using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 velocity = gameObject.GetComponent<Rigidbody2D>().velocity;
		velocity.x += Random.Range (-0.2f, 0.2f);
		velocity.y += Random.Range (-0.2f, 0.2f);
		gameObject.GetComponent<Rigidbody2D>().velocity = velocity;
	}
}
