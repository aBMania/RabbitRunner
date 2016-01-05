using UnityEngine;
using System.Collections;

[RequireComponent (typeof (MeshRenderer))]
public class SolidObstacle : Obstacle {

	MeshRenderer meshRenderer;

	public void Awake()
	{
		meshRenderer = GetComponent<MeshRenderer>();
	}

	public override void setColor(Color color){
		meshRenderer.material.color = color;
	}
}
