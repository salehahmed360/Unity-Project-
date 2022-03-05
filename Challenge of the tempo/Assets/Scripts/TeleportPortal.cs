using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPortal : MonoBehaviour
{

    private AudioSource inputSound;
    //outputPortal object
    public GameObject outputPortal;
    //detects the box placed on input portal

    private void Start()
    {
        inputSound = gameObject.GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(DelayTeleportAction(3f, collision)); //delay time using the delay action which takes in the time to delay
 
     

    }
    //checks its portal box and teleports it into the center of the outputPortal
    void teleportBox(GameObject box)
    {
        if (box.gameObject.CompareTag("teleportBox") && box != null)
        {
            //get the center of the output portal to move the box into the center 
            var center = outputPortal.GetComponent<Renderer>().bounds.center;
            box.transform.position = center;
        }
    }

    //delay for certain amount of time and calls the teleportBox function
    public IEnumerator DelayTeleportAction(float time, Collision collision)
    {
        yield return new WaitForSeconds(time);
        inputSound.Play();
        teleportBox(collision.gameObject);
    }
}
