using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueTrigger : MonoBehaviour
{
    public List<GameObject> blueBoxes;
    public bool[] allIn;
    public Color origonalColor;
    public Renderer color;
    public bool blueCheck;// = false; 
    void Start()
    {

        blueBoxes = new List<GameObject>(); //store the collided boxes
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
            if (collision.gameObject.tag == "bluebox1" || collision.gameObject.tag == "bluebox2" || collision.gameObject.tag == "bluebox3")
            {
                blueBoxes.Add(collision.gameObject); //only adds one
            }
        }
        for (int i = 0; i < 3; i++)
        {
            allIn[i] = false;
        }
        for (int i = 0; i < blueBoxes.Count; i++)
        {
            if (blueBoxes[i].tag == "bluebox1")
            {
                allIn[0] = true;
            }
            if (blueBoxes[i].tag == "bluebox2")
            {
                allIn[1] = true;
            }
            if (blueBoxes[i].tag == "bluebox3")
            {
                allIn[2] = true;
            }
        }
        //as all boxes are in blueboxes so are detected and placed in the trigger it can set doit to true
        bool doIt = true;

        for (int i = 0; i < 3; i++)
        {
            if (!allIn[i]) //if its not true then dont trigger nothing it goes index 0, index 1, index 2 which are all <3 and checks if each one is false 
            {
                doIt = false;
                blueCheck = false;
            }
        }
        //as doit is true due to all boxes being deteced then we can trigger to make it blue 
        if (doIt)
        {

            color.material.SetColor("_Color", Color.blue); //must have _Color otherwise it wont work 
            blueCheck = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {

        if (blueBoxes.IndexOf(collision.gameObject) > -1) //becuase we removed a box so that means the list is not full 
        {
            if (blueBoxes.Contains(collision.gameObject))
            {
                blueCheck = false;

                blueBoxes.Remove(collision.gameObject); //remove that box you moved out 
                color.material.SetColor("_Color", origonalColor); //must have _Color otherwise it wont work 

            }
        }
    }
}
