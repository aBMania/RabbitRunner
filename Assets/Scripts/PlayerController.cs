using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour {

	static float speed;
	static float distance;
	float angularSpeed;
	float timeElapsed;
	float direction;
	float smoothing;
    Color color = Color.white;

    // Use this for initialization
    void Start() {
		angularSpeed = 500f;
		speed = 20f;
		timeElapsed = 0f;
		smoothing = 2.5f;
	}

	void Update() {
		direction = Input.GetAxis("Horizontal");
		timeElapsed += Time.deltaTime;
		speed += Time.deltaTime * smoothing;

		turn(direction);
		moveForward();
	}

    void turn(float direction) {
		float angle = direction * angularSpeed * Time.deltaTime;
		transform.RotateAround(Vector3.zero, Vector3.forward, angle);
	}

	void moveForward()	{
		float tempdistance = speed * Time.deltaTime;
		transform.Translate (transform.forward * tempdistance);
		distance = transform.position.z;
	}

	public static float getSpeed() {
		return speed;
	}

	public static float getDistance() {
		return distance;
	}


    public Color getColor()
    {
        return color;
    }

    public void setColor(Color color)
    {
        this.color = color;
        Debug.Log("le joueur devient " + color);

        MeshRenderer renderer = GetComponent<MeshRenderer>();

        renderer.material.color = color;
    }

}
