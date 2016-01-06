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
	float tempSpeed = 20f;
	bool dead = false;
	bool stopped;
	ObstacleColor color = ObstacleColor.White;

    // Use this for initialization
    void Start() {
		startRunning();
	}

	void Update() {
		if (!dead && !stopped) {
			direction = Input.GetAxis ("Horizontal");
			timeElapsed += Time.deltaTime;
			speed += Time.deltaTime * smoothing;

			turn (direction);
			moveForward ();
		}
	}

	public void startRunning() {
		angularSpeed = 500f;
		speed = tempSpeed;
		timeElapsed = 0f;
		smoothing = 2.5f;
		stopped = false;
	}

	public void stopRunning() {
		angularSpeed = 0f;
		tempSpeed = speed;
		speed = 0f;
		stopped = true;
	}

	public bool isStopped() {
		return stopped;
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

	public ObstacleColor getColor()
    {
        return color;
    }

    public void setObstacleColor(ObstacleColor color)
    {
        this.color = color;
    }

	public void setColor(Color color)
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
		renderer.material.color = color;
    }

	public void death() {
		dead = true;
	}

	public bool isDead() {
		return dead;
	}
}
