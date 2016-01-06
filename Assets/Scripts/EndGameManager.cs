using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndGameManager : MonoBehaviour {

	public Button endButton;
	public GameObject player;
	public GameObject hudCanvas;

	bool created;
	PlayerController playerController;
	Button buttonClone;

	// Use this for initialization
	void Start () {
		playerController = player.GetComponent<PlayerController>();
		created = false;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (playerController.isDead() && !created) {
			Debug.Log ("creating button");
			created = true;
			buttonClone = Instantiate(endButton, new Vector3 (Screen.width/2, Screen.height/2, 0), Quaternion.identity) as Button;
			buttonClone.transform.SetParent(hudCanvas.transform);
		}
	}
}
