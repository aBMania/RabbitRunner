﻿using UnityEngine;
using System.Collections;
using System;

public class ObstacleController : MonoBehaviour
{
    public GameObject player;
	public ObstacleColor color;
    PlayerController playerController;

    public void Start()
    {
		playerController = player.GetComponent<PlayerController>();
		setColor (getRealColor(color));
	}

    void OnTriggerEnter(Collider other) {
        if (other.gameObject == player) {
            onPlayerHit();
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
			realColor = Color.blue;
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