using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalDoor : MonoBehaviour
{
    public GameObject parent; //using parent object to access its children to stop null pointer reference
    private doorTrigger doorTrigger;
    private Animator door;
    void Start()
    {
        door = parent.transform.GetChild(0).GetComponent<Animator>();
        doorTrigger = parent.transform.GetChild(1).GetComponent<doorTrigger>(); //accessing the last index which is the trigger and getting the doorTrigger script

    }

    // Update is called once per frame
    void Update()
    {
        doorOpenening();
        doorClosing();
    }
    public void doorOpenening()
    {
        if (doorTrigger.doorStatues == true)
        {
            door.SetBool("isOpening", true); 

        }
    } 
    public void doorClosing()
    {
        if (doorTrigger.doorStatues == false)
        {
            door.SetBool("isOpening", false); 
        }
    }

}
