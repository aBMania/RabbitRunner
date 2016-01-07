﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDManager : MonoBehaviour {

	public Text speedTextPrefab;
	public Text distanceTextPrefab;
	public Text instructionsTextPrefab;
	public GameObject player;

	bool tutorial = true;
	Text instructions, distance, speed;
	PlayerController playerController;

	void Awake() {
		playerController = player.GetComponent<PlayerController>();
	}

	// Use this for initialization
	void Start() {
		instructions = Instantiate(instructionsTextPrefab, new Vector3(Screen.width/2, Screen.height/2, 0), Quaternion.identity) as Text;
		instructions.transform.SetParent(transform);
	}
	
	// Update is called once per frame
	void Update() {
		// if enter key or button 0 pressed, and in tutorial, launch game 
		if ((Input.GetKeyDown ("joystick button 0") || Input.GetKeyDown (KeyCode.Return)) && tutorial) { 
			tutorial = false;
			Destroy(instructions);
			displayInformations ();
		} else if (!tutorial) {
			speed.text = "Speed: " + Mathf.Round(playerController.getSpeed() * 10f) / 10f + " km/h";
			distance.text = "Distance: " + Mathf.Round(playerController.getDistance() * 10f) / 10f + " m";
		}
	}

	void displayInformations() {
		distance = Instantiate(distanceTextPrefab, new Vector3(10, Screen.height-10, 0), Quaternion.identity) as Text;
		distance.transform.SetParent(transform);
		speed = Instantiate(speedTextPrefab, new Vector3(10, Screen.height-30, 0), Quaternion.identity) as Text;
		speed.transform.SetParent(transform);
	}

	public bool inTutorial() {
		return tutorial;
	}
}