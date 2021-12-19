using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject parent; //using parent object to access its children to stop null pointer reference
    private doorTrigger doorTrigger; 
    private Animator animDoorLeft;    
    private Animator animDoorRight;
    void Start()
    {
        //print(parent.transform.childCount); 
        animDoorLeft = parent.transform.GetChild(0).GetComponent <Animator>();  //accessing first object in parent and accessing the animator component
        animDoorRight = parent.transform.GetChild(1).GetComponent<Animator>();
        doorTrigger = parent.transform.GetChild(2).GetComponent<doorTrigger>(); //accessing the last index which is the trigger and getting the doorTrigger script
    }

    // Update is called once per frame
    void Update()
    {
        doorOpenening();
        doorClosing();
    }

    /*
     * doorTrigger has doorStatues method that returns true if collides with box 
     * if its true sets the left and right door bool in animation to true 
     * this then open both doors 
     */
    public void doorOpenening()
    {
        if (doorTrigger.doorStatues == true)
        {
            animDoorLeft.SetBool("LDisOpening", true);
            animDoorRight.SetBool("RDisOpening", true);

        } 
    }

    /*
     * checking if doorStatues is false which becomes false if there is no box on trigger
     * the then puts both doors to closing state as its false
     */
    public void doorClosing()
    {
        if (doorTrigger.doorStatues == false)
        {
            animDoorLeft.SetBool("LDisOpening", false);
            animDoorRight.SetBool("RDisOpening", false);
        }
    }
}
