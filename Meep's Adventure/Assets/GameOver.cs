using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("level");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
