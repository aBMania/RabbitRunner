using UnityEngine;
using System.Collections;

public class CylinderManager : MonoBehaviour {

	public Transform playerTransform;
    public CylinderGenerator CG;
	public TextMesh positionTextPrefab;

    int cylinderLength = 400;
	int shift = 100;
	int textMeshOffset = 25;
	Transform currentCylinder;
	Transform frontCylinder;
	TextMesh first, second, third, fourth, fifth;
	float firstZ = ScoreList.getList()[0],
		secondZ = ScoreList.getList()[1],
		thirdZ = ScoreList.getList()[2],
		fourthZ = ScoreList.getList()[3],
		fifthZ = ScoreList.getList()[4];

	// Use this for initialization
	void Start () {

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
