using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;//remove mouse from locking to screen 
        Cursor.visible = true; //makes the cursor visible
    }
    public void PlayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1); 
    }
}
