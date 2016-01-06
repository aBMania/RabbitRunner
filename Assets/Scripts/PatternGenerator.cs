using UnityEngine;
using System.Collections.Generic;

public class PatternGenerator : MonoBehaviour {

    ObstacleGenerator obstacleGenerator;
    static float cylinderRadius = 5f;
    static float patternLength = 100f;

    static float zMin = -patternLength/2;
    static float zMax = +patternLength/2;

    static List<Pattern> patternList;

    static int lastPatternIndex;

    static PatternGenerator()
    {
        patternList = new List<Pattern>();

        patternList.Add(delegate (ObstacleGenerator OG) {
            GameObject pattern = new GameObject();

            List<GameObject> patternObstacles = new List<GameObject> {
                OG.generateVerticalLaser (zMin, ObstacleColor.Blue),
                OG.generateHorizontalLaser (zMin, ObstacleColor.Red),
                OG.generateRopeLaser(0, 0.4f, 90, ObstacleColor.Green),
                OG.generateRopeLaser(0, 0.4f, -90, ObstacleColor.Green),
                OG.generateHalfWall(0, 0.35f, 0.5f,  0, ObstacleColor.White)
            };

            foreach (GameObject obstacle in patternObstacles) {
                obstacle.transform.SetParent(pattern.transform);
            }

            return pattern;
        });

		patternList.Add(delegate (ObstacleGenerator OG) {
			GameObject pattern = new GameObject();

			List<GameObject> patternObstacles = new List<GameObject> {
				OG.generateHalfWall(zMin + patternLength/4, 0.5f, 0.25f, 35f, ObstacleColor.White),
				OG.generateRopeLaser(zMin + patternLength/4 + 10, 0.1f, 15f, ObstacleColor.Blue),
				OG.generateRopeLaser(zMin + patternLength/4 + 10, 0.2f, 15f, ObstacleColor.Blue),
				OG.generateRopeLaser(zMin + patternLength/4 + 10, 0.3f, 15f, ObstacleColor.Blue),
				OG.generateRopeLaser(zMin + patternLength/4 + 10, 0.4f, 15f, ObstacleColor.Blue),
				OG.generateRopeLaser(zMin + patternLength/4 + 10, 0.5f, 15f, ObstacleColor.Blue)
			};

			foreach (GameObject obstacle in patternObstacles) {
				obstacle.transform.SetParent(pattern.transform);
			}

			return pattern;			
		});

		patternList.Add(delegate (ObstacleGenerator OG) {
			GameObject pattern = new GameObject();
			List<GameObject> patternObstacles = new List<GameObject>();

			for (int i = 0 ; i < 20 ; i++) {
				patternObstacles.Add(OG.generateRopeLaser(zMin + i*patternLength/20, 1f, 10f*i, ObstacleColor.Green));
			}

			foreach (GameObject obstacle in patternObstacles) {
				obstacle.transform.SetParent(pattern.transform);
			}

			return pattern;
		});

		patternList.Add (delegate (ObstacleGenerator OG) {
			GameObject pattern = new GameObject ();

			List<GameObject> patternObstacles = new List<GameObject> ();

			for (int i = 0; i < 3; i++) {
				// add rotation
				patternObstacles.Add (OG.generateRopeLaser(zMin + i * patternLength / 3, 1f, 60f * i, ObstacleColor.Red, 30));
			}

			foreach (GameObject obstacle in patternObstacles) {
				obstacle.transform.SetParent (pattern.transform);
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
        int r;

        do
            r = Random.Range(0, patternList.Count);
        while (r == lastPatternIndex);
            
        lastPatternIndex = r;
        GameObject pattern = patternList[r](obstacleGenerator);
        pattern.transform.Rotate(Vector3.forward, Random.Range(-179, 180));
        return pattern;
    }

    public float getPatternLength()
    {
        return patternLength;
    }
}
