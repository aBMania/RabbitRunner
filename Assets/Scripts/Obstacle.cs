using UnityEngine;
using System.Collections;
using System;

public class Obstacle : MonoBehaviour
{
    public GameObject player;
    public Collider obstacleCollider;
    public ObstacleColor color;

    void Update() {

    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject == player) {
            onPlayerHit();
        }
    }

    void onPlayerHit() {
		Debug.Log ("player");   
    }
}
