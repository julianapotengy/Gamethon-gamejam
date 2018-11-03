using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ChangeToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ChangeToGame()
    {
        SceneManager.LoadScene(1);

    }
}
