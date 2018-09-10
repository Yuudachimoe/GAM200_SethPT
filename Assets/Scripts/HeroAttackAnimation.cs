using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttackAnimation : MonoBehaviour {

	// Use this for initialization
	public GameObject HSABeam;
	public GameObject HABeam;
	public GameObject GM;
	float isHSA = 0;
	float isHA = 0;
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
		if (isHA != 0) {
			isHA -= Time.deltaTime;
			if (isHA < 0) {
				ZeroTp (HABeam);
				GM.GetComponent<GameManager> ().HeroDmgDealt ();
				isHA = 0;
			}
		}
		if (isHSA != 0) {
			isHSA -= Time.deltaTime;
			if (isHSA < 0) {
				ZeroTp (HSABeam);
				GM.GetComponent<GameManager> ().HeroDmgDealt ();
				isHSA = 0;
			}
		}

		/*
		if (isHA != 0 || isHSA != 0 ) {
			isHA -= Time.deltaTime;
			isHSA -= Time.deltaTime;
			if (isHA < 0) {
				ZeroTp (HABeam);
				GM.GetComponent<GameManager> ().HeroDmgDealt ();
				isHA = 0;
			}
			if (isHSA < 0) {
				ZeroTp (HSABeam);
				GM.GetComponent<GameManager> ().HeroDmgDealt ();
				isHSA = 0;
			}
			return;
		}
		if (Input.GetKey ("e"))
			HeroSuperAttack ();
		if (Input.GetKey ("r"))
			HeroAttack ();
		*/
	}
	public void HeroSuperAttack(){
		FullTp (HSABeam);
		isHSA = 1;
	}
	public void HeroAttack(){
		FullTp (HABeam);
		isHA = 1;
	}
}
