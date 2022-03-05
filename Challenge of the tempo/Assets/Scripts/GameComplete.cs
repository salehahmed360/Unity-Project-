using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameComplete : MonoBehaviour
{
    private AudioSource gameCompleteAudio;
    void Start()
    {
        gameCompleteAudio = gameObject.GetComponent<AudioSource>();
        gameCompleteAudio.Play();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) //to reset the game
        {
            Restart();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            gameCompleteAudio.Stop();
            SceneManager.LoadScene(0);//loads menu screen
        }
    }

    public void GameCompletion() //activate the game complete screen
    {
        this.gameObject.SetActive(true);
    }


    public void Restart()
    {
        Time.timeScale = 1; //stops the game from moving 
        gameCompleteAudio.Stop();
        SceneManager.LoadScene(1); //restart to level 1 or 2


    }
}
