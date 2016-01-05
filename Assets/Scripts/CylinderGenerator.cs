using UnityEngine;
using System.Collections.Generic;
using System;

public class CylinderGenerator : MonoBehaviour {

    public GameObject cylinder;

	float cylinderLength = 200f;

    public GameObject newCylinder(Vector3 position, Quaternion rotation, bool firstCylinder = false)
    {
		GameObject newCylinder = Instantiate(cylinder, position, rotation) as GameObject;
		ObstacleGenerator OG = GetComponent<ObstacleGenerator> ();

		List<GameObject> cylinderObstacles = new List<GameObject> {
			OG.generateVerticalLaser (position.z + cylinderLength/2, ObstacleColor.Blue),
			OG.generateHorizontalLaser (position.z + cylinderLength/2, ObstacleColor.Red),
		};

		foreach(GameObject obstacle in cylinderObstacles)
		{
			obstacle.transform.parent = newCylinder.transform;
		}


		return newCylinder;
    }
}
