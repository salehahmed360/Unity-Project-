using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorTrigger : MonoBehaviour
{
    private GameObject doorBox;
    public bool doorStatues; //if the doorTrigger has a box on it or not

    void Start()
    {
        doorStatues = false; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 
    public void OnTriggerEnter(Collider other) //detects a box with name tag doorBox and sets the doorStatues to true to open the door
    {
        if (other.CompareTag("doorBox"))
        {
            doorStatues = true;
        }
    }

    public void OnTriggerExit(Collider other) //upon removing the box sets the doorStatues to false 
    { 
            doorStatues = false; 
    }
}
