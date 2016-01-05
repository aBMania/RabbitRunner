using UnityEngine;
using System.Collections;

[RequireComponent (typeof (MeshRenderer))]
public class SolidObstacle : Obstacle {

	MeshRenderer renderer;

	public void Awake()
	{
		renderer = GetComponent<MeshRenderer>();
	}

	public override void setColor(Color color){
		renderer.material.color = color;
	}
}
