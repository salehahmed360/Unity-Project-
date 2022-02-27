using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class is only for door triggers which have cutscenes as not all have it
public class CutSceneDoorTrigger : MonoBehaviour
{
    public GameObject cutScene;
    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("doorBox") || other.CompareTag("teleportBox"))
        {
            cutScene.SetActive(true);
        }
    } 
}
