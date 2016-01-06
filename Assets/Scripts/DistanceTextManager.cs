using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DistanceTextManager : MonoBehaviour {

	Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
	}

	// Update is called once per frame
	void Update () {
		text.text = "Distance: " + Mathf.Round(PlayerController.getDistance() * 10f) / 10f + " m";
	}
}
