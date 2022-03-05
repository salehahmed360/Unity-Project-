using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class is only for door triggers which have cutscenes as not all have it
public class CutSceneDoorTrigger : MonoBehaviour
{
    public GameObject cutScene; 

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("doorBox") || other.CompareTag("teleportBox"))
        {
            if (cutScene != null) { 
                cutScene.SetActive(true); //activates the cutScene which runs the cutScene
            }
        }
    } 
}
