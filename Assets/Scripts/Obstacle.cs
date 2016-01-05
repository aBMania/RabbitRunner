using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(MeshRenderer))]

public class Obstacle : MonoBehaviour
{
    public GameObject player;
    PlayerController playerController;
    Color color;

<<<<<<< HEAD
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        color = renderer.material.color;
=======
    void Update() {

>>>>>>> 2830b7970ed547a98ce8b8835065b7f21730564b
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject == player) {
            onPlayerHit();
        }
    }

<<<<<<< HEAD
    void onPlayerHit()
    {
        Color playerColor = playerController.getColor();

        if(playerColor == color || color == Color.white)
        {
            Debug.Log("Le joueur meurt");
            return;
        }

        playerController.setColor(color);
        
=======
    void onPlayerHit() {
		Debug.Log ("player");   
>>>>>>> 2830b7970ed547a98ce8b8835065b7f21730564b
    }
}
