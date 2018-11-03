using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {

	[Header("Bullet Speed")]
	public float speed;

	void Start () 
	{
		
	}
	
	void Update () 
	{
		transform.Translate (Vector3.right * speed * Time.deltaTime);
	}
}
