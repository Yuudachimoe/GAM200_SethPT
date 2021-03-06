using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaling : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	private bool scaling_flag = false;
	// Update is called once per frame
	void Update () {
		Vector3 scaling = gameObject.transform.localScale;
		if (scaling.x >= 1)
			scaling_flag = false;
		else if (scaling.x <= 0.7)
			scaling_flag = true;
		if (!scaling_flag) {
			scaling.x -= Time.deltaTime * 1.0f;
			scaling.y -= Time.deltaTime * 1.0f;
		}
		else  {
			scaling.x += Time.deltaTime * 1.0f;
			scaling.y += Time.deltaTime * 1.0f;
		}
		gameObject.transform.localScale = scaling;
	}
}
