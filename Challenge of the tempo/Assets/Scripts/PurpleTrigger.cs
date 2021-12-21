﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleTrigger : MonoBehaviour
{
    public List<GameObject> purpleBoxes;
    public bool[] allIn;
    public Color origonalColor;
    public Renderer color;
    public bool purpleCheck;// = false; 
    void Start()
    {

        purpleBoxes = new List<GameObject>(); //store the collided boxes
        allIn = new bool[3]; //each box is assigned true or false if all in greenBoxes
        color = gameObject.GetComponent<Renderer>(); //access box colour
        origonalColor = color.material.color; //gets the original colour on the box and stores it in this variable
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {


        if (collision.gameObject.layer == 9) //checks if its a box layer
        {
            if (collision.gameObject.tag == "purplebox1" || collision.gameObject.tag == "purplebox2" || collision.gameObject.tag == "purplebox3")
            {
                purpleBoxes.Add(collision.gameObject); //only adds one
            }
        } 
        for (int i = 0; i < 3; i++)
        {
            allIn[i] = false;
        }
        for (int i = 0; i < purpleBoxes.Count; i++)
        {
            if (purpleBoxes[i].tag == "purplebox1")
            {
                allIn[0] = true;
            }
            if (purpleBoxes[i].tag == "purplebox2")
            {
                allIn[1] = true;
            }
            if (purpleBoxes[i].tag == "purplebox3")
            {
                allIn[2] = true;
            }
        }
        //as all boxes are in purpleboxes so are detected and placed in the trigger it can set doit to true
        bool doIt = true;

        for (int i = 0; i < 3; i++)
        {
            if (!allIn[i]) //if its not true then dont trigger nothing it goes index 0, index 1, index 2 which are all <3 and checks if each one is false 
            {
                doIt = false;
                purpleCheck = false;
            }
        }
        //as doit is true due to all boxes being deteced then we can trigger to make it purple 
        if (doIt)
        {

            color.material.color = new Color(128,0,128); //must have _Color otherwise it wont work 
            purpleCheck = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {

        if (purpleBoxes.IndexOf(collision.gameObject) > -1) //becuase we removed a box so that means the list is not full 
        {
            if (purpleBoxes.Contains(collision.gameObject))
            {
                purpleCheck = false;

                purpleBoxes.Remove(collision.gameObject); //remove that box you moved out 
                color.material.SetColor("_Color", origonalColor); //must have _Color otherwise it wont work 

            }
        }
    }
}