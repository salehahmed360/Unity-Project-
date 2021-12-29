using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class TimerTest
    {

        //this test checks the timer reaches 0 after 5 seconds
        //setted the timer to 3 seconds and waited 5 seconds to 
        //see if its going to becomes negative
       
    


        [UnityTest]
        public IEnumerator Timer_Reaches0()
        {

            var timerObj = GameObject.Instantiate(new GameObject());
            timerObj.AddComponent<Text>();
            var timer = timerObj.AddComponent<Timer>(); 
            var gameOverObj = GameObject.Instantiate(new GameObject());
            var gameover = gameOverObj.AddComponent<GameOverScreen>();

            timerObj.name = "Timer";
            timer.timevalue = 3f; 
            timer.gameOver = gameover;

            yield return new WaitForSecondsRealtime(3); 
            Assert.AreEqual(0, timer.timevalue);
        }

        //checks GameOverScreen is active once the timer hits 0 
        [UnityTest]
        public IEnumerator Timer_GameOverScreen_Active()
        {
            var timerObj = GameObject.Instantiate(new GameObject());
            timerObj.AddComponent<Text>();
            var timer = timerObj.AddComponent<Timer>();  
            var gameOverObj = GameObject.Instantiate(new GameObject());
            var gameover = gameOverObj.AddComponent<GameOverScreen>();

            gameOverObj.SetActive(false);
            gameOverObj.name = "GameOverScreen";
            timerObj.name = "Timer";
            timer.timevalue = 2f; 
            timer.gameOver = gameover;

            //WaitForSecondsRealtime doesnt get effected by Time.scaledtime i.e. pausing the game
             yield return new WaitForSecondsRealtime(3);
             Assert.AreEqual(true,gameOverObj.activeSelf); 
        }
    }
}
