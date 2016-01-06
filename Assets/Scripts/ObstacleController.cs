﻿using UnityEngine;
using System.Collections;
using System;

public class ObstacleController : MonoBehaviour
{
    public GameObject player;
	public ObstacleColor color;
    PlayerController playerController;
	float angularSpeed = 0f;

    public void Start() {
		playerController = player.GetComponent<PlayerController>();
		setColor (getRealColor(color));
	}

	public void Update() {
		if (angularSpeed != 0) {
			float angle = angularSpeed * Time.deltaTime;
			transform.RotateAround(Vector3.zero, Vector3.forward, angle);
		}
	}

	public void setAngularSpeed(float angSpeed) {
		angularSpeed = angSpeed;
	}

	public float getAngularSpeed() {
		return angularSpeed;
	}

    void OnTriggerEnter(Collider other) {
		if (other.gameObject == player && !playerController.isInCollision()) {
			playerController.setInCollision(true);
            onPlayerHit();
        }
    }

	void OnTriggerExit(Collider other) {
		if (!playerController)
			return;
		
		if (playerController.isInCollision()) {
			playerController.setInCollision(false);
		}
	}
			
    void onPlayerHit()
	{
		ObstacleColor playerColor = playerController.getColor ();

		if (playerColor == color || color == ObstacleColor.White) {
			playerController.death ();
			return;
		}

        playerController.setObstacleColor(color);
		playerController.setColor (getRealColor(color));
	}

	public virtual void setColor(Color color)
	{
		
	}

	public void setColor(ObstacleColor color)
	{
		this.color = color;
		setColor(getRealColor (color));
	}

	public Color getRealColor(ObstacleColor color)
	{
		Color realColor;

		switch(color)
		{
		case ObstacleColor.Blue:
			realColor = Color.cyan;
			break;
		case ObstacleColor.Green:
			realColor = Color.green;
			break;
		case ObstacleColor.Red:
			realColor = Color.red;
			break;
		case ObstacleColor.White:
		default:
			realColor = Color.white;
			break;
		}

		return realColor;
	}
}
