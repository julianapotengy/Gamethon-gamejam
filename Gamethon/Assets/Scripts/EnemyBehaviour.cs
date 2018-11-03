using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

	public enum IAMode{ PigGround, PigFly, BoarGround }

	[Header("Comportamento do Inimigo")]
	public IAMode thisEnemyMode;

	[Header("Referencia do Player")]
	public Transform player;

	float xPos;
	float yPos;

	float velocity;

	bool voar;
	bool lado;
	bool teVi;

	float shotCooldown;

	[Header("Limites do Voo Y (Ground)")]
	public float yMax_ground;
	public float yMin_ground;

	[Header("Limites do Voo X (Fly)")]
	public float xMax_fly;
	public float xMin_fly;

	[Header("Pig Poop")]
	public Transform pigBulletReference;
	public GameObject pigBullet;

	void Start () 
	{
		voar = true;
		lado = true;
		teVi = false;
		switch(thisEnemyMode)
		{
		case IAMode.PigGround:
			velocity = 3f;
			yPos = 2f;
			break;
		case IAMode.PigFly:
			velocity = 4f;
			yPos = 8.5f;
			xPos = 24f;
			break;
		case IAMode.BoarGround:
			velocity = 5f;
			yPos = 1.6f;
			xPos = 14.11f;
			break;
		}
	}
	
	void Update () 
	{
		switch(thisEnemyMode)
		{
		case IAMode.PigGround:
			PigGround ();
			Shot (3f);
			break;
		case IAMode.PigFly:
			PigFly ();
			Shot (1.5f);
			break;
		case IAMode.BoarGround:
			BoarGround ();
			break;
		}

		transform.position = Vector3.Lerp(this.transform.position, new Vector3 (xPos, yPos, 0), 2f * Time.deltaTime);
	}

	void Shot(float time)
	{
		shotCooldown += 1f * Time.deltaTime;

		if (shotCooldown > time) {
			Instantiate (pigBullet, pigBulletReference.position, Quaternion.identity);
			shotCooldown = 0;
		}
	}

	void PigGround()
	{
		if (xPos > player.position.x + 0.1f) {
			transform.localEulerAngles = new Vector3 (0, 0, 0);
			xPos -= velocity * Time.deltaTime;
		}
		else if (xPos < player.position.x - 0.1f) {
			transform.localEulerAngles = new Vector3 (0, 180, 0);
			xPos += velocity * Time.deltaTime;
		}

		if (yPos > yMax_ground && voar) {
			voar = false;
		}
		else if (yPos < yMin_ground && !voar) {
			voar = true;
		}

		yPos = voar ? yPos += (velocity/2) * Time.deltaTime : yPos -= (velocity/2) * Time.deltaTime;
	}

	void PigFly()
	{
		if (xPos > xMax_fly && lado) {
			lado = false;
		}
		else if (xPos < xMin_fly && !lado) {
			lado = true;
		}

		xPos = lado ? xPos += velocity * Time.deltaTime : xPos -= velocity * Time.deltaTime;
		transform.localEulerAngles = lado ? new Vector3 (0, 180, 0) : new Vector3 (0, 0, 0);
	}

    void BoarGround()
    {
        if (teVi)
        {
            if (xPos > player.position.x + 0.1f)
            {
                transform.localEulerAngles = new Vector3(0, 0, 0);
                xPos -= velocity * Time.deltaTime;
            }
            else if (xPos < player.position.x - 0.1f)
            {
                transform.localEulerAngles = new Vector3(0, 180, 0);
                xPos += velocity * Time.deltaTime;
            }
        }

        GetComponent<Animator>().SetBool("teVi", teVi);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (thisEnemyMode == IAMode.BoarGround && col.gameObject.name == "Player")
        {
            teVi = true;
        }
    }
}
