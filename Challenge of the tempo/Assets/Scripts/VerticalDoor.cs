using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalDoor : MonoBehaviour
{
    public GameObject parent; //using parent object to access its children to stop null pointer reference
    private DoorTrigger doorTrigger;
    private Animator door;
    void Start()
    {
        door = parent.transform.GetChild(0).GetComponent<Animator>(); //accessing the door gameObject to get its animation component
        doorTrigger = parent.transform.GetChild(1).GetComponent<DoorTrigger>(); //accessing the last index which is the trigger and getting the doorTrigger script

    }
    void Update()
    {
        doorOpenening();
        doorClosing();
    }
    public void doorOpenening()
    {
        if (doorTrigger.doorStatues == true)
        {
            door.SetBool("isOpening", true); //activate the opening animation

        }
    } 
    public void doorClosing()
    {
        if (doorTrigger.doorStatues == false)
        {
            door.SetBool("isOpening", false); //activate the closing animation
        }
    }

}
