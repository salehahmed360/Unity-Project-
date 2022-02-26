using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private AudioSource buttonPressed; 

    private void Start()
    {
        buttonPressed = this.GetComponent<AudioSource>(); 

        Cursor.lockState = CursorLockMode.None;//remove mouse from locking to screen 
        Cursor.visible = true; //makes the cursor visible
    }
    public void PlayGame()
    {
        Time.timeScale = 1;
        buttonPressed.Play();
        StartCoroutine(DelayScreenAction(0.3f));
    }

    public IEnumerator DelayScreenAction(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(1); 
    }
}
