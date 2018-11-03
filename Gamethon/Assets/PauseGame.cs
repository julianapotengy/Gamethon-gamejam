using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private bool isPaused;
    public GameObject pauseMenuUI;
    public GameObject textGame;

	void Start ()
    {
        isPaused = false;
        Time.timeScale = 1;
	}
	
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else Pause();
        }
	}

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        textGame.SetActive(true);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        textGame.SetActive(false);
        Time.timeScale = 0;
        isPaused = true;
    }
}
