using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Button endButton;
	public GameObject player;
	public GameObject hudCanvas;
	public Text pauseText;

	bool created = false;
	bool pause = false;
	PlayerController playerController;
	Button buttonClone = null;
	Text tempPauseText;

	// Use this for initialization
	void Awake () {
		playerController = player.GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		// if the button hasn't been createed yet and if the player's dead
		if (playerController.isDead() && !created) {
			created = true;
			buttonClone = Instantiate(endButton, new Vector3 (Screen.width/2, Screen.height/2, 0), Quaternion.identity) as Button;
			buttonClone.transform.SetParent(hudCanvas.transform);
		}

		// simulates click on button from joystick
		if (Input.GetKeyDown("joystick 1 button 0") && buttonClone != null) {
			buttonClone.onClick.Invoke();
		}

		// if the player isn't dead and if we pressed either space or button 0 from joystick
		if ((Input.GetKeyDown("space") || Input.GetKeyDown("joystick 1 button 0")) && !playerController.isDead()) {
			if (pause) {
				pause = false;
				Destroy(tempPauseText.gameObject);
				playerController.startRunning();
			} else {
				pause = true;
				tempPauseText = instantiatePauseText();
				playerController.stopRunning();
			}
		}
	}

	Text instantiatePauseText() {
		Text text = Instantiate(pauseText, new Vector3(Screen.width/2, Screen.height/2, 0), Quaternion.identity) as Text;
		text.transform.SetParent(hudCanvas.transform);
		return text;
	}
}
