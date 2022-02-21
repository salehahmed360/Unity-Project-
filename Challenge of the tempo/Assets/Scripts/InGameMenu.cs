using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InGameMenu : MonoBehaviour
{
    public static bool gameIsPaused = true;

    public void PlayGame()
    {
        SceneManager.LoadScene(1);

        Resume();

    }
    public void Pause()
    {
        Time.timeScale = 0;
        gameIsPaused = false;
    }
    public void Resume()
    {
        Time.timeScale = 1;
        gameIsPaused = true;
    }
}
