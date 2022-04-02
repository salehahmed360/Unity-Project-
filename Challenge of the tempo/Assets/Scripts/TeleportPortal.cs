using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPortal : MonoBehaviour
{

    private AudioSource inputSound;//sound when teleport box is placed on teleport input
    //outputPortal object
    public GameObject outputPortal;
    //detects the box placed on input portal
    public bool isPlaced; //if player removes box from input teleport it gets activated to false only teleports if its true

    private void Start()
    {
        inputSound = gameObject.GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("teleportBox") && collision != null) 
        {
            isPlaced = true;
            StartCoroutine(DelayTeleportAction(3f, collision)); //delay time using the delay action which takes in the time to delay 
        }

    }
    //checks its portal box and teleports it into the center of the outputPortal
    void TeleportBox(GameObject box)
    {
            //get the center of the output portal to move the box into the center 
            var center = outputPortal.GetComponent<Renderer>().bounds.center;
            box.transform.position = center; //position box into the center of the output teleport 
    }

    //delay for certain amount of time and calls the teleportBox function
    public IEnumerator DelayTeleportAction(float time, Collision collision)
    {
        yield return new WaitForSeconds(time);
        if (collision.gameObject.CompareTag("teleportBox") && collision != null && isPlaced == true) //issue when placing and removing the box on teleport it still telelport even though box is removed where to solve this isPlaced checks if the box is still on input teleport or removed
        {
            inputSound.Play();
            TeleportBox(collision.gameObject);
        }
        
      
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("teleportBox"))
        {
            isPlaced = false;
        }
        
    }
}
