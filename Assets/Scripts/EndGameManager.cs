using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndGameManager : MonoBehaviour {

	public Button endButton;
	public GameObject player;
	public GameObject hudCanvas;

	bool created = false;
	PlayerController playerController;
	Button buttonClone = null;

	// Use this for initialization
	void Awake () {
		playerController = player.GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (playerController.isDead() && !created) {
			created = true;
			buttonClone = Instantiate(endButton, new Vector3 (Screen.width/2, Screen.height/2, 0), Quaternion.identity) as Button;
			buttonClone.transform.SetParent(hudCanvas.transform);
		}

		if (Input.GetKeyDown("joystick 1 button 0") && buttonClone != null) {
			buttonClone.onClick.Invoke();
		}
	}
}
