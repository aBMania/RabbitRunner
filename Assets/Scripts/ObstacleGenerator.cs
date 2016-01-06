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

        LaserObstacleController obstacleController = laserInstance.GetComponent<LaserObstacleController> ();

		obstacleController.player = player;
		obstacleController.setColor (color);

		LineRenderer renderer = laserInstance.GetComponent<LineRenderer> ();
		renderer.SetPosition(0, new Vector3(-1, 0, 0));
		renderer.SetPosition(1, new Vector3(1, 0, 0));

		return laserInstance;
	}

	public GameObject generateVerticalLaser(float z, ObstacleColor color)
	{
        return generateRopeLaser(z, 1, 90, color);
    }

	public GameObject generateHorizontalLaser(float z, ObstacleColor color)
	{
		return generateRopeLaser (z, 1, 0, color);
	}

    public GameObject generateRopeLaser(float z, float distanceToWall, float angle, ObstacleColor color)
    {        
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        Vector3 leftPoint = rotation * new Vector3(-cylinderRadius, (1 - distanceToWall) * cylinderRadius, z);
        Vector3 rightPoint = rotation * new Vector3(+cylinderRadius, (1 - distanceToWall) * cylinderRadius, z);


        return generateLaser(leftPoint, rightPoint, rotation, color);
    }

    public GameObject generateHalfWall (float z, float distanceToWall, float height, float angle, ObstacleColor color)
    {
        GameObject halfWallInstance = Instantiate(halfWall, z * Vector3.forward, Quaternion.identity) as GameObject;

        halfWallInstance.transform.localScale = new Vector3(halfWallInstance.transform.localScale.x, halfWallInstance.transform.localScale.y * height, halfWallInstance.transform.localScale.z);
        halfWallInstance.transform.Translate(Vector3.down * (1.5f - distanceToWall) * cylinderRadius);
        halfWallInstance.transform.RotateAround(Vector3.zero, Vector3.forward, angle);
        

        SolidObstacleController obstacleController = halfWallInstance.GetComponent<SolidObstacleController>();

        obstacleController.player = player;
        obstacleController.setColor(color);

        return halfWallInstance;
    }
}
