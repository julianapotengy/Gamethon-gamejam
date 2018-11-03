using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCircle : MonoBehaviour
{
    public Image[] circles;
    public int playerLife;
    
	void Start ()
    {
		
	}
	
	void Update ()
    {
		if(playerLife == 3)
        {
            circles[0].gameObject.SetActive(true);
            circles[1].gameObject.SetActive(true);
            circles[2].gameObject.SetActive(true);
        }
        if (playerLife == 2)
        {
            circles[0].gameObject.SetActive(true);
            circles[1].gameObject.SetActive(true);
            circles[2].gameObject.SetActive(false);
        }
        if (playerLife == 1)
        {
            circles[0].gameObject.SetActive(true);
            circles[1].gameObject.SetActive(false);
            circles[2].gameObject.SetActive(false);
        }
    }
}
