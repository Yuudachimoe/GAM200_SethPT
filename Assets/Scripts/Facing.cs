using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Facing : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 new_velocity = gameObject.GetComponent<Rigidbody2D> ().velocity;
		Vector3 scale = gameObject.GetComponent<Transform> ().localScale;
		if (new_velocity.x * scale.x > 0)
			scale.x = -scale.x;
		gameObject.GetComponent<Transform> ().localScale = scale;
	}
}
