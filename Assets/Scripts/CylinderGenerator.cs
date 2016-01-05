using UnityEngine;
using System.Collections;
using System;

public class CylinderGenerator : MonoBehaviour {

    public GameObject cylinder;

    public GameObject newCylinder(Vector3 position, Quaternion rotation, bool firstCylinder = false)
    {
        return Instantiate(cylinder, position, rotation) as GameObject;
    }
}
