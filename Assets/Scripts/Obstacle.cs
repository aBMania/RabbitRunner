using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(MeshRenderer))]

public class Obstacle : MonoBehaviour
{
    public GameObject player;
    PlayerController playerController;
    Color color;

    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        color = renderer.material.color;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            onPlayerHit();
        }
    }

    void onPlayerHit()
    {
        Color playerColor = playerController.getColor();

        if(playerColor == color || color == Color.white)
        {
            Debug.Log("Le joueur meurt");
            return;
        }

        playerController.setColor(color);
        
    }
}
