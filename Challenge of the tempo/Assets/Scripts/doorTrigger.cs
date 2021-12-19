using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorTrigger : MonoBehaviour
{
    public GameObject doorBox;
    public bool doorStatues;

    void Start()
    {
        doorStatues = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("doorBox"))
        {
            doorStatues = true;
        }
    }

    public void OnTriggerExit(Collider other)
    { 
            doorStatues = false; 
    }
}
