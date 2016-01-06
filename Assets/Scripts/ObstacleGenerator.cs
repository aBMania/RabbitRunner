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

        Vector3 center = (point2 + point1)/2;

        laserInstance = Instantiate(laser, center, quaternion) as GameObject;

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
        return generateRopeLaser(z, cylinderRadius, 90, color);
    }

	public GameObject generateHorizontalLaser(float z, ObstacleColor color)
	{
		return generateRopeLaser (z, cylinderRadius, 0, color);
	}

    public GameObject generateRopeLaser(float z, float distanceToWall, float angle, ObstacleColor color)
    {        
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        Vector3 leftPoint = rotation * new Vector3(-cylinderRadius, distanceToWall - cylinderRadius, z);
        Vector3 rightPoint = rotation * new Vector3(+cylinderRadius, distanceToWall - cylinderRadius, z);


        return generateLaser(leftPoint, rightPoint, rotation, color);
    }
}
