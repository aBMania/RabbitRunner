using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Button endButton;
	public GameObject player;
	public GameObject hudCanvas;
	public Text pauseText;

	bool created = false;
	bool pause = true;
	bool tutorial = true;
	PlayerController playerController;
	Button buttonClone = null;
	Text tempPauseText = null;

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

		// simulates click on button from joystick or on return key down
		if ((Input.GetKeyDown("joystick button 0") || Input.GetKeyDown(KeyCode.Return)) && buttonClone != null) {
			buttonClone.onClick.Invoke();
		}

		// if the player isn't dead and if we pressed either return or button 0 from joystick (and if we're not in tutorial)
		if ((Input.GetKeyDown("joystick button 0") || Input.GetKeyDown(KeyCode.Return)) && !playerController.isDead() && !playerController.getHUDManager().inTutorial()) {
			if (pause) {
				pause = false;
				if (tempPauseText != null) {
					Destroy (tempPauseText.gameObject);
				}
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
