using UnityEngine;
using System.Collections.Generic;

public class PatternGenerator : MonoBehaviour {

    ObstacleGenerator obstacleGenerator;
    static float cylinderRadius = 5f;
    static float patternLength = 100f;

    static float zMin = -patternLength/2;
    static float zMax = +patternLength/2;

    static List<Pattern> patternList;

    static PatternGenerator()
    {
        patternList = new List<Pattern>();

        patternList.Add(delegate (ObstacleGenerator OG)
        {

            GameObject pattern = new GameObject();

            List<GameObject> patternObstacles = new List<GameObject> {
                OG.generateVerticalLaser (zMin, ObstacleColor.Blue),
                OG.generateHorizontalLaser (zMin, ObstacleColor.Red),
                OG.generateRopeLaser(0, 0.2f, 90, ObstacleColor.Green),
                OG.generateRopeLaser(0, 0.2f, -90, ObstacleColor.Green),
                OG.generateHalfWall(0, 1f, 0.5f, 45, ObstacleColor.White)
            };

            foreach (GameObject obstacle in patternObstacles)
            {
                obstacle.transform.SetParent(pattern.transform);
            }

            return pattern;

        });
    }

    void Awake()
    {
        obstacleGenerator = GetComponent<ObstacleGenerator>();
    }

	public GameObject newPattern(int difficulty)
    {
        int r = Random.Range(0, patternList.Count - 1);

        return patternList[r](obstacleGenerator);
    }

    public float getPatternLength()
    {
        return patternLength;
    }
}
