using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamagePlayer : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject damageEffect;
    private float counter;
    private bool canCount;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        damageEffect = GameObject.Find("DamageImage");
        damageEffect.GetComponent<Animator>().SetBool("damaging", false);
        counter = 0;
        canCount = false;
    }

    void Update()
    {
        if(canCount)
        {
            counter += Time.deltaTime;
            if(counter >= 1f)
            {
                counter = 0;
                damageEffect.GetComponent<Animator>().SetBool("damaging", false);
                canCount = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            canCount = true;
            damageEffect.GetComponent<Animator>().SetBool("damaging", true);
            gameManager.GetComponent<LifeCircle>().playerLife -= 1;
        }
    }
}
