using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public GameObject character;
	public GameObject MarkSign;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Transform player_t = character.GetComponent<Transform> ();
		Transform target_t = gameObject.GetComponent<Transform> ();
		float distance = Vector3.Distance (player_t.position, target_t.position);
		if (distance <= 10 && MarkSign != null) {
			Color tmp =	MarkSign.GetComponent<SpriteRenderer>().color;
			tmp = new Color (255f, 0f, 0f);
			MarkSign.GetComponent<SpriteRenderer>().color = tmp;
		}
		else if (MarkSign != null)
		{
			Color tmp =	MarkSign.GetComponent<SpriteRenderer>().color;
			tmp = new Color (255f, 255f, 255f);
			MarkSign.GetComponent<SpriteRenderer>().color = tmp;
		}
	}
}
