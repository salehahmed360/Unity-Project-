using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal2 : MonoBehaviour
{
    Sector2B sector2b;
    public GameComplete gamecomplete;
    
    void Start()
    {
        sector2b = GameObject.FindGameObjectWithTag("sector2b").GetComponent<Sector2B>();
        
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