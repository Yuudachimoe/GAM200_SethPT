using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputControl : MonoBehaviour {
	public GameObject Character;
	public Text Current_Speed;
	public GameObject Up;
	public GameObject Down;
	public GameObject Left;
	public GameObject Right;
	public GameObject Space;
	public GameObject Z;
	public GameObject X;
	public GameObject C;
	public GameObject Sequence;
	public GameObject GM;
	public int Character_Speed;

	private bool facing_flag = false;
	private bool isPressed = false;
	private string pressedKey = "";
	// Use this for initialization
	void Start () {
		
	}

	void FullTp(GameObject obj)
	{
		Color tmp = obj.GetComponent<Image>().color;
		tmp.a = 1.0f;
		obj.GetComponent<Image> ().color = tmp;
	}

	void HalfTp(GameObject obj)
	{
		Color tmp = obj.GetComponent<Image>().color;
		tmp.a = 0.5f;
		obj.GetComponent<Image> ().color = tmp;
	}


	void ResetInput()
	{
		if (Up != null)
			HalfTp (Up);
		if (Down != null)
			HalfTp (Down);
		if (Left != null)
			HalfTp (Left);
		if (Right != null)
			HalfTp (Right);
		if (Space != null)
			HalfTp (Space);
		if (Z != null)
			HalfTp (Z);
		if (X != null)
			HalfTp (X);
		if (C != null)
			HalfTp (C);
	}

	void SetPressed(string str)
	{
		pressedKey = str;
		isPressed = true;
		if (Sequence != null) {
			Sequence.GetComponent<InputSequenceMg> ().CheckInput (str);
		}
	}
	// Update is called once per frame
	void Update () {
		if (Character == null)
			return;
		Rigidbody2D moving_block = Character.GetComponent<Rigidbody2D> ();
		/*if (Current_Speed != null) {
			Current_Speed.text = character_speed.x.ToString() + ","+ character_speed.y.ToString();
		}*/

		Vector3 new_velocity = new Vector3 (0, 0, 0);

		if (pressedKey != "" && isPressed == true) {
			if (Input.GetKey (pressedKey))
				return;
			else {
				pressedKey = "";
				isPressed = false;
				ResetInput ();
			}
				
		}

		if (Input.GetKey("up")){
			new_velocity.y += Character_Speed;
			FullTp (Up);
			SetPressed ("up");
		}
		if (Input.GetKey("down")){
			new_velocity.y -= Character_Speed;
			FullTp (Down);
			SetPressed ("down");
		}
		if (Input.GetKey("right")){
			new_velocity.x += Character_Speed;
			FullTp (Right);
			SetPressed ("right");
		}
		if (Input.GetKey("left")){
			new_velocity.x -= Character_Speed;
			FullTp (Left);
			SetPressed ("left");
		}	
		if (Input.GetKey ("space")) {
			FullTp (Space);
			SetPressed ("space");
		}
		if (Input.GetKey ("z")) {
			FullTp (Z);
			SetPressed ("z");
		}
		if (Input.GetKey ("x")) {
			FullTp (X);
			SetPressed ("x");
		}
		if (Input.GetKey ("c")) {
			FullTp (C);
			SetPressed ("c");
		}
		if (Input.GetKey ("r")) {
			GM.GetComponent<GameManager> ().RestartGame ();
		}
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit ();
		}
			
		moving_block.velocity = new_velocity;
	}
}
