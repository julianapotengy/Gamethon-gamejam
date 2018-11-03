using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungryBar : MonoBehaviour
{
    public Image hungryBar;
    public bool coolingDown;
    public float waitTime;

    void Start()
    {
        waitTime = 50.0f;
    }

    void Update()
    {
        if (coolingDown == true)
        {
            hungryBar.fillAmount -= 0.03f * Time.deltaTime;
        }
    }
}
