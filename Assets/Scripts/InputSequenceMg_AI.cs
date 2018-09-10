using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InputSequenceMg_AI : MonoBehaviour {

	public Text T_Sequence;
	public Text T_TotalChar;
	public Text T_RightChar;
	public GameObject GM;
	public float correct_ratio;
	public float reaction_time;
	// Use this for initialization0
	private bool AI_flag;
	private int cursor;
	private int counter;
	private float timer;
	private int total_length;
	private string current_sequence;
	private string keys = "↑↓←→ZXC";
	void Start () {
		GenerateNewSequence ();
	}
		
	void DisplaySequence(string str)
	{
		string tmp = "";
		for(int u =0 ; u<str.Length; u++)
			tmp += str[u] +" ";
		if (T_Sequence != null)
			T_Sequence.text = tmp;
	}
	public void GenerateNewSequence()
	{
		counter = 0;
		cursor = 0;
		current_sequence = "";
		timer = 0;
		AI_flag = false;
		current_sequence = "";
		total_length = Random.Range (5, 8);
		counter = 0;
		if (T_TotalChar != null)
			T_TotalChar.text = total_length.ToString ();
		if (T_RightChar != null)
			T_RightChar.text = 0.ToString ();
		for (int u = 0; u < total_length; u++) {
			int randomness = Random.Range (0, 6);
			current_sequence += keys [randomness];
		}
		DisplaySequence (current_sequence);
	}
	public void CheckInput(string str)
	{
		char check;
		if (str == "up")
			check = '↑';
		else if (str == "down")
			check = '↓';
		else if (str == "left")
			check = '←';
		else if (str == "right")
			check = '→';
		else
			check = char.ToUpper(str [0]);

		if (current_sequence [0] == check) {
			counter++;
			T_RightChar.text = counter.ToString ();
		}
		current_sequence = current_sequence.Substring (1);
		DisplaySequence (current_sequence);
		if (current_sequence == "") {
			Debug.Log ("E_ATTACK "+( (float)((float)counter / (float)total_length)).ToString ());
			GM.GetComponent<GameManager> ().EnemyDealDmg (((float)counter / (float)total_length));
			AI_flag = false;
		}
	}

	// Update is called once per frame
	void Update () {
		if (AI_flag) {
			timer += Time.deltaTime;
			if (timer > reaction_time) {
				float randonness = Random.value;
				if (randonness <= correct_ratio)
					CheckInput (current_sequence [0].ToString());
				else
					CheckInput (" ");
				timer = 0;
			}
		}
	}
	public void ActivateAI(){
		AI_flag = true;
	}

}
