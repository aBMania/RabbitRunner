using UnityEngine;
using System.Collections;

public class ObstacleGenerator : MonoBehaviour {

	public GameObject laser;
	public GameObject halfWall;
	public GameObject player;

	float cylinderRadius = 5f;

	public GameObject generateLaser(Vector3 point1, Vector3 point2, Quaternion quaternion, ObstacleColor color)
	{
		GameObject laserInstance;

		laserInstance = Instantiate(laser, new Vector3(0, 0, point1.z), quaternion) as GameObject;

		LaserObstacle obstacleController = laserInstance.GetComponent<LaserObstacle> ();

		obstacleController.player = player;
		obstacleController.setColor (color);

		LineRenderer renderer = laserInstance.GetComponent<LineRenderer> ();
		renderer.SetPosition(0, point1);
		renderer.SetPosition(1, point2);

		return laserInstance;
	}

	public GameObject generateVerticalLaser(float z, ObstacleColor color)
	{
		Vector3 bottomPoint = new Vector3 (0, -cylinderRadius, z);
		Vector3 topPoint = new Vector3 (0, +cylinderRadius, z);

		return generateLaser (bottomPoint, topPoint, Quaternion.identity, color);
	}

	public GameObject generateHorizontalLaser(float z, ObstacleColor color)
	{
		Vector3 leftPoint = new Vector3 (-cylinderRadius, 0, z);
		Vector3 rightPoint = new Vector3 (+cylinderRadius, 0, z);

		return generateLaser (leftPoint, rightPoint, Quaternion.AngleAxis(90, Vector3.forward), color);
	}
}
