using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal2 : MonoBehaviour
{
    private Sector2B sector2b;
    public GameComplete gamecomplete; //accessing the game complete script to activate the game complete screen
    
    void Start()
    {
        sector2b = GameObject.FindGameObjectWithTag("sector2b").GetComponent<Sector2B>(); //finds object with sector2b tag and gets the script compoenents class SectorB to check if level has been completed or not
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player")) //checks player crossed
        {
            if (sector2b.levelComplete == true)
            {
                Time.timeScale = 0; //pause time
                gamecomplete.GameCompletion();  //loads game complete 
            }
        }
    }
}