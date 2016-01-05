using UnityEngine;
using System.Collections;

public class CylinderManager : MonoBehaviour {

	public Transform cylinder;
	public Transform playerTransform;

	int cylinderLength = 400;
	int shift = 20;
	Transform currentCylinder;
	Transform frontCylinder;

	// Use this for initialization
	void Start () {
		// instantiation the first two cylinders
		currentCylinder = Instantiate(cylinder, new Vector3(0, 0, 0), Quaternion.identity) as Transform;
		frontCylinder = Instantiate(cylinder, new Vector3(0, 0, cylinderLength), Quaternion.identity) as Transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (isPlayerAfterCurrentCylinder()) {
			Destroy(currentCylinder.gameObject);
			currentCylinder = frontCylinder;
			frontCylinder = Instantiate(
				cylinder, 
				new Vector3(0, 0, cylinderLength + currentCylinder.transform.position.z), 
				Quaternion.identity
			) as Transform;
		}
	}

	bool isPlayerAfterCurrentCylinder() {
		return playerTransform.position.z > currentCylinder.transform.position.z + cylinderLength / 2 + shift;
	}
}
