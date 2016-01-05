using UnityEngine;
using System.Collections;

public class CylinderManager : MonoBehaviour {

	public Transform playerTransform;
    public CylinderGenerator CG;

    int cylinderLength = 400;
	int shift = 20;
	Transform currentCylinder;
	Transform frontCylinder;
    

	// Use this for initialization
	void Start () {
        currentCylinder = CG.newCylinder(new Vector3(0, 0, 0), Quaternion.identity, true).transform;
		frontCylinder = CG.newCylinder(new Vector3(0, 0, cylinderLength), Quaternion.identity).transform;
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
