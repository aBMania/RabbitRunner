using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PatternGenerator : MonoBehaviour {

    ObstacleGenerator OG;
    static float cylinderRadius = 5f;
    static float patternLength = 100f;
    static float z0 = -patternLength/2;

    void Awake()
    {
        OG = GetComponent<ObstacleGenerator>();
    }

	public GameObject newPattern(int difficulty)
    {
        GameObject pattern = new GameObject();

        List<GameObject> cylinderObstacles = new List<GameObject> {
            OG.generateVerticalLaser (z0, ObstacleColor.Blue),
            OG.generateHorizontalLaser (z0, ObstacleColor.Red),

            OG.generateRopeLaser(0, cylinderRadius, Random.Range(1, 180), ObstacleColor.Green)
        };

        foreach (GameObject obstacle in cylinderObstacles)
        {

            obstacle.transform.parent = pattern.transform;
        }

        return pattern;

    }

    public float getPatternLength()
    {
        return patternLength;
    }
}
