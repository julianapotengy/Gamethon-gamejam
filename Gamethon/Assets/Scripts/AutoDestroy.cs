using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour {

	[Header("Tempo para autodestruir")]
	public float time;

	void Update () 
	{
		Destroy (gameObject, time);
	}
}
