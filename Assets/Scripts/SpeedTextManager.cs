using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpeedTextManager : MonoBehaviour {

	Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Speed: " + Mathf.Round(PlayerController.getSpeed() * 10f) / 10f + " km/h";
	}
}
