using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverScreen : MonoBehaviour
{
    public bool active = false;
    private AudioSource gameOverAudio;
    void Start()
    {
        gameOverAudio = gameObject.GetComponent<AudioSource>();
        if (gameOverAudio != null)
        {
            gameOverAudio.Play();
        }
        }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.E)) //restart game
        {
            Restart();
        }
        if (Input.GetKeyDown(KeyCode.M)) //return to menu
        {
            SceneManager.LoadScene(0);//loads menu screen
            if (gameOverAudio != null)
            {
                
                gameOverAudio.Stop();
            }
        }
    }

    public void GameOver()
    {
        
        active = true; //to test the game over screen is activated
        this.gameObject.SetActive(true);
       
    }


    public void Restart() //restart the game from level 1
    {
        
        active = false;
        Time.timeScale = 1; //as time stopped this returns it back to normal

        if (gameOverAudio != null)
        {
            gameOverAudio.Stop();
          
        }
        SceneManager.LoadScene(1); //restart to level 1 or 2

    }

}
