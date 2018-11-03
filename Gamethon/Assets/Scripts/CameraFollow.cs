using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	[Header("Alvo")]
	public Transform target;

	[Header("Altura")]
	public float yPos;

	void Update () 
	{
		transform.position = Vector3.Lerp (this.transform.position, new Vector3 (target.position.x, yPos, -5), 3f * Time.deltaTime);
	}
}
