using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public bool doorStatues; //if the doorTrigger has a box on it or not 

    public AudioSource doorOpen, doorClose;
    void Start()
    {
        doorStatues = false; 
    }
 
    public void OnTriggerEnter(Collider other) //detects a box with name tag doorBox and sets the doorStatues to true to open the door
    {
        if (other.CompareTag("doorBox") || other.CompareTag("teleportBox"))
        {
            
            doorStatues = true; 
            doorOpen.Play(); 

        }
    }

    public void OnTriggerExit(Collider other) //upon removing the box sets the doorStatues to false 
    {
            doorClose.Play();
            doorStatues = false; 
    }
}
