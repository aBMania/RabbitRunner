using UnityEngine;
using System.Collections.Generic;

public class PatternGenerator : MonoBehaviour {

    ObstacleGenerator obstacleGenerator;
    static float patternLength = 100f;

    static float zMin = -patternLength/2;
    static float zMax = +patternLength/2;

    static List<Pattern> patternList;

    static int lastPatternIndex;

    static PatternGenerator()
    {
        patternList = new List<Pattern>();

		patternList.Add(delegate (ObstacleGenerator OG, List<ObstacleColor> randomColorList) {

            List<GameObject> patternObstacles = new List<GameObject> {
				OG.generateVerticalLaser (zMin,  randomColorList[0]),
				OG.generateHorizontalLaser (zMin,  randomColorList[1]),
				OG.generateRopeLaser(0, 0.4f, 90,  randomColorList[2]),
				OG.generateRopeLaser(0, 0.4f, -90,  randomColorList[2]),
                OG.generateHalfWall(0, 0.35f, 0.5f,  0, ObstacleColor.White)
            };
				
			return patternObstacles;
        });

		patternList.Add(delegate (ObstacleGenerator OG, List<ObstacleColor> randomColorList) {
			List<GameObject> patternObstacles = new List<GameObject> {
				OG.generateCircleWall(zMin + patternLength/4, 1f, 1f, 35f, ObstacleColor.White),
				OG.generateRopeLaser(zMin + patternLength/4 + 10, 0.1f, 15f, randomColorList[0]),
				OG.generateRopeLaser(zMin + patternLength/4 + 10, 0.2f, 15f, randomColorList[0]),
				OG.generateRopeLaser(zMin + patternLength/4 + 10, 0.3f, 15f, randomColorList[0]),
				OG.generateRopeLaser(zMin + patternLength/4 + 10, 0.4f, 15f, randomColorList[0]),
				OG.generateRopeLaser(zMin + patternLength/4 + 10, 0.5f, 15f, randomColorList[0])
			};

			return patternObstacles;
		});

		patternList.Add(delegate (ObstacleGenerator OG, List<ObstacleColor> randomColorList) {
			List<GameObject> patternObstacles = new List<GameObject>();

			for (int i = 0 ; i < 20 ; i++) {
				patternObstacles.Add(OG.generateRopeLaser(zMin + i*patternLength/20, 1f, 10f*i, randomColorList[0]));
			}

			return patternObstacles;

		});

		patternList.Add (delegate (ObstacleGenerator OG, List<ObstacleColor> randomColorList) {

			List<GameObject> patternObstacles = new List<GameObject> ();

			for (int i = 0; i < 3; i++) {
				patternObstacles.Add (OG.generateRopeLaser(zMin + i * patternLength / 3, 1f, 60f * i, randomColorList[0], 30));
			}
				
			return patternObstacles;
		});
	}

    void Awake()
    {
        obstacleGenerator = GetComponent<ObstacleGenerator>();
    }

	public GameObject newPattern(int difficulty)
    {
        int i;

        do
            i = Random.Range(0, patternList.Count);
        while (i == lastPatternIndex);
            
        lastPatternIndex = i;

		List<GameObject> patternObstacles = patternList[i](obstacleGenerator, getRandomObstacleList());

		GameObject pattern = new GameObject ();

		foreach (GameObject obstacle in patternObstacles) {
			obstacle.transform.SetParent (pattern.transform);
		}
			
        pattern.transform.Rotate(Vector3.forward, Random.Range(-179, 180));
        return pattern;
    }

	public List<ObstacleColor> getRandomObstacleList()
	{
		ObstacleColor[] randomObstacleArray = (ObstacleColor[]) System.Enum.GetValues (typeof(ObstacleColor));
		List<ObstacleColor> randomObstacleList = new List<ObstacleColor> (randomObstacleArray);

		randomObstacleList.Remove (ObstacleColor.White);

		randomObstacleList.Sort ((a, b) => 1 - 2 * Random.Range (0, 2));

		return randomObstacleList;
	}

    public float getPatternLength()
    {
        return patternLength;
    }
}
