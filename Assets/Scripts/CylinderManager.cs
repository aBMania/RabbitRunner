using UnityEngine;
using System.Collections;

public class CylinderManager : MonoBehaviour {

	public Transform playerTransform;
    public CylinderGenerator CG;
	public TextMesh positionTextPrefab;

    int cylinderLength = 400;
	int shift = 100;
	int textMeshOffset = 40;
	Transform currentCylinder;
	Transform frontCylinder;
	TextMesh first, second, third, fourth, fifth;
	float firstZ = 0f, secondZ = 0f, thirdZ = 0f, fourthZ = 0f, fifthZ = 0f;

	// Use this for initialization
	void Start () {
		if (ScoreList.getList().Count >= 1)
			firstZ = ScoreList.getList()[0];

		if (ScoreList.getList().Count >= 2)
			secondZ = ScoreList.getList()[1];

		if (ScoreList.getList().Count >= 3)
			thirdZ = ScoreList.getList()[2];

		if (ScoreList.getList().Count >= 4)
			fourthZ = ScoreList.getList()[3];
		
		if (ScoreList.getList().Count >= 5)
			fifthZ = ScoreList.getList()[4];

		if (secondZ - firstZ < textMeshOffset) {
			secondZ = firstZ + textMeshOffset;
		}

		if (thirdZ - secondZ < textMeshOffset) {
			thirdZ = secondZ + textMeshOffset;
		}

		if (fourthZ - thirdZ < textMeshOffset) {
			fourthZ = thirdZ + textMeshOffset;
		}

		if (fifthZ - fourthZ < textMeshOffset) {
			fifthZ = fourthZ + textMeshOffset;
		}

        currentCylinder = CG.newCylinder(new Vector3(0, 0, 0), Quaternion.identity, true).transform;
		frontCylinder = CG.newCylinder(new Vector3(0, 0, cylinderLength), Quaternion.identity).transform;
		first = Instantiate(positionTextPrefab, new Vector3 (0, 0, firstZ), Quaternion.identity) as TextMesh;
		first.text = "1st";
		second = Instantiate(positionTextPrefab, new Vector3 (0, 0, ScoreList.getList()[1]), Quaternion.identity) as TextMesh;
		second.text = "2nd";
		third = Instantiate(positionTextPrefab, new Vector3 (0, 0, ScoreList.getList()[2]), Quaternion.identity) as TextMesh;
		third.text = "3rd";
		fourth = Instantiate(positionTextPrefab, new Vector3 (0, 0, ScoreList.getList()[3]), Quaternion.identity) as TextMesh;
		fourth.text = "4th";
		fifth = Instantiate(positionTextPrefab, new Vector3 (0, 0, ScoreList.getList()[4]), Quaternion.identity) as TextMesh;
		fifth.text = "5th";
	}
	
	// Update is called once per frame
	void Update () {
		if (isPlayerAfterCurrentCylinder()) {
			Destroy(currentCylinder.gameObject);
			currentCylinder = frontCylinder;
            frontCylinder = CG.newCylinder(
                new Vector3(0, 0, cylinderLength + currentCylinder.transform.position.z), 
                Quaternion.identity
            ).transform;
		}
	}

	bool isPlayerAfterCurrentCylinder() {
		return playerTransform.position.z > currentCylinder.transform.position.z + cylinderLength / 2 + shift;
	}
}
