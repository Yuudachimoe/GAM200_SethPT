using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	public Text BaseText;
	public Text CurrentText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RectTransform transform = gameObject.GetComponent<RectTransform>();
		transform.sizeDelta = new Vector2 (300 * int.Parse (CurrentText.text) / int.Parse (BaseText.text),50);
	}
}
