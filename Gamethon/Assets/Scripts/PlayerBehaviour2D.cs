using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour2D : MonoBehaviour {

	Animator anim;

	Vector3 position;

	float positionX, positionY;
	float velocity;

	[Header("Bullet Prefab")]
	public Transform bulletReference;
	public GameObject bullet;

	[Header("Limites")]
	public float xMin;
	public float xMax;

	void Start () 
	{
		anim = GetComponent<Animator> ();
		positionY = 1.5f;
		velocity = 8f;
	}
	
	void Update () 
	{
		move ();

		if (Input.GetMouseButtonDown (0))
			Instantiate (bullet, bulletReference.position, transform.rotation);

		anim.SetFloat ("speed_x", Mathf.Abs(Input.GetAxis("Horizontal")));
	}

	//FUNÇÕES PARA MOVIMENTAÇÃO
	void move()
	{
		positionX += (Input.GetAxis ("Horizontal") * velocity) * Time.deltaTime;
		position = new Vector3 (positionX, transform.position.y, 0f);

		limitYPos ();
		flip ();

		transform.position = position;
	}

	void limitYPos()
	{
		if (positionX > xMax)		positionX = xMax;
		else if (positionX < xMin)	positionX = xMin;
	}
	void flip()
	{
		if (Input.GetAxis ("Horizontal") > 0)	transform.localEulerAngles = new Vector3 (0, 0, 0);
		else if (Input.GetAxis ("Horizontal") < 0)	transform.localEulerAngles = new Vector3 (0, 180, 0);
	}
}
