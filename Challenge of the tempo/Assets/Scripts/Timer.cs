﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
     
    public float timevalue = 60f;
    public Text timerText;

    public  GameOverScreen gameOver;

    // Start is called before the first frame update
    void Start()
    {
         timerText = GetComponent<Text>(); 
          timerText.text = "00:00";
    }

    // Update is called once per frame
    void Update()
    {
        if(timevalue > 0)
        {
            timevalue -= Time.deltaTime;
        }
        else
        {
            timevalue = 0; 
            Time.timeScale = 0;
             
            gameOver.GameOver();  
        }
          
        DisplayTime(timevalue);

    }

    public void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);//round timer to minutes
        float seconds = Mathf.FloorToInt(timeToDisplay % 60); //round timer to seconds by using modula

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);//the format which the time will be displayed
    }


}
