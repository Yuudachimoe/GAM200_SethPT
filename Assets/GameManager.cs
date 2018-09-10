using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	public int enemyhp;
	public int herohp;
	public int hero_attack;
	public int hero_super_attack;
	public int enemy_attack;
	public int enemy_super_attack;

	public Text T_hero_max_hp;
	public Text T_hero_hp;
	public Text T_enemy_max_hp;
	public Text T_enemy_hp;

	public GameObject Ani_hero;
	public GameObject Ani_enemy;
	public GameObject AS_hero;
	public GameObject AS_enemy;
	public GameObject AI;
	public GameObject Seq_hero;
	public GameObject Seq_enemy;
	public GameObject Rs_win;
	public GameObject Rs_defeat;

	void Start () {
		T_hero_hp.text = herohp.ToString();
		T_hero_max_hp.text = herohp.ToString ();
		T_enemy_hp.text = enemyhp.ToString ();
		T_enemy_max_hp.text = enemyhp.ToString ();
		AS_enemy.SetActive (false);
		AS_hero.SetActive (true);
		Rs_win.SetActive (false);
		Rs_defeat.SetActive (false);
	}
	public void RestartGame()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
	// Update is called once per frame
	void Update () {
		
	}
	public void HeroDealDmg(float percentage){
		if (percentage == 1) {
			enemyhp -= hero_super_attack;
		} 
		else {
			enemyhp -= (int)(((float)hero_attack * percentage));
		}
		if (Ani_hero != null) {
			if (percentage != 1)
				Ani_hero.GetComponent<HeroAttackAnimation> ().HeroAttack();
			else 
				Ani_hero.GetComponent<HeroAttackAnimation>().HeroSuperAttack();
		}

	}
	public void HeroDmgDealt(){
		if(T_enemy_hp != null)
			T_enemy_hp.text = enemyhp.ToString ();
		if (!HealthCheck()) {
			Seq_enemy.GetComponent<InputSequenceMg_AI> ().GenerateNewSequence ();
			AS_hero.SetActive (false);
			AS_enemy.SetActive (true);
			AI.GetComponent<InputSequenceMg_AI> ().ActivateAI ();
		}
	}

	public void EnemyDealDmg(float percentage){
		if (percentage == 1) {
			herohp -= enemy_super_attack;
		} 
		else
			herohp -= (int)(((float)enemy_attack * percentage));
		if (Ani_enemy != null) {
			if (percentage != 1)
				Ani_enemy.GetComponent<EnemyAttackAnimation> ().EnemyAttack ();
			else
				Ani_enemy.GetComponent<EnemyAttackAnimation> ().EnemySuperAttack ();
	}
	}
	public void EnemyDmgDealt(){
		if (T_hero_hp != null)
			T_hero_hp.text = herohp.ToString();
		if (!HealthCheck()) {
			Seq_hero.GetComponent<InputSequenceMg> ().GenerateNewSequence ();
			AS_enemy.SetActive (false);
			AS_hero.SetActive (true);
		}
		
	}
	bool HealthCheck(){
		if (herohp <= 0) {
			AS_enemy.SetActive (false);
			AS_hero.SetActive (false);
			Rs_defeat.SetActive (true);
			return true;
		}
		if (enemyhp <= 0) {
			AS_enemy.SetActive (false);
			AS_hero.SetActive (false);
			Rs_win.SetActive (true);
			return true;
		}
		return false;
	}



}
