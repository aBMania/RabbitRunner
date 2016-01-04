using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float angularSpeed;
	public float speed;

	// Use this for initialization
	void Start () {
	
	}

	void Update () {
		float v = Input.GetAxis ("Horizontal");

		Tourner (v);
		Avancer ();
	}

	void Tourner (float v)
	{
		float angle = v * angularSpeed * Time.deltaTime;
		transform.RotateAround(Vector3.zero, Vector3.forward, angle);
	}

	void Avancer ()
	{
		float distance = speed * Time.deltaTime;
		transform.Translate (transform.forward * distance); 
	}
}
