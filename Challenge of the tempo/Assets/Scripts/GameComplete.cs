﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameComplete : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Restart();
        }
    }

    public void GameCompletion()
    {
        this.gameObject.SetActive(true);
    }


    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0); //restart to level 1 or 2

    }
}