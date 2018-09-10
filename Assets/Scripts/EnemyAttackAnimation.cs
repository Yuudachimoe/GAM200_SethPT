using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttackAnimation : MonoBehaviour {

	// Use this for initialization
	public GameObject ESABeam;
	public GameObject EABeam;
	public GameObject GM;
	float isESA = 0;
	float isEA = 0;
	void Start () {
		
	}
	void FullTp(GameObject obj)
	{
		Color tmp = obj.GetComponent<SpriteRenderer>().color;
		tmp.a = 1.0f;
		obj.GetComponent<SpriteRenderer> ().color = tmp;
	}

	void ZeroTp(GameObject obj)
	{
		Color tmp = obj.GetComponent<SpriteRenderer>().color;
		tmp.a = 0.0f;
		obj.GetComponent<SpriteRenderer> ().color = tmp;
	}
	// Update is called once per frame
	void Update () {
		if (isEA != 0) {
			isEA -= Time.deltaTime;
			if (isEA < 0) {
				ZeroTp (EABeam);
				GM.GetComponent<GameManager> ().EnemyDmgDealt ();
				isEA = 0;
			}
		}
		if (isESA != 0) {
			isESA -= Time.deltaTime;
			if (isESA < 0) {
				ZeroTp (ESABeam);
				GM.GetComponent<GameManager> ().EnemyDmgDealt ();
				isESA = 0;
			}
		}
		/*
		if (isEA != 0 || isESA != 0 ) {
			isEA -= Time.deltaTime;
			isESA -= Time.deltaTime;
			if (isEA < 0) {
				ZeroTp (EABeam);
				GM.GetComponent<GameManager> ().EnemyDmgDealt ();
				isEA = 0;

			}
			if (isESA < 0) {
				ZeroTp (ESABeam);
				GM.GetComponent<GameManager> ().EnemyDmgDealt ();
				isESA = 0;
			}
			return;
		}
		if (Input.GetKey ("q"))
			EnemySuperAttack ();
		if (Input.GetKey ("w"))
			EnemyAttack ();
			*/
			
	}
	public void EnemySuperAttack(){
		FullTp (ESABeam);
		isESA = 1;
	}
	public void EnemyAttack(){
		FullTp (EABeam);
		isEA = 1;
	}
}
