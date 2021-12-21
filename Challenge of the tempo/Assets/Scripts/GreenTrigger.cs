using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenTrigger : MonoBehaviour
{
    public List<GameObject> greenBoxes;
    public bool[] allIn;
    public Color origonalColor;
    public Renderer color;
    public bool greenCheck;// = false; 
    void Start()
    {

        greenBoxes = new List<GameObject>(); //store the collided boxes
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
            if (collision.gameObject.tag == "greenbox1" || collision.gameObject.tag == "greenbox2" || collision.gameObject.tag == "greenbox3")
            {

                greenBoxes.Add(collision.gameObject); //only adds one
            }
        }
        for (int i = 0; i < 3; i++)
        {
            allIn[i] = false;
        }
        for (int i = 0; i < greenBoxes.Count; i++)
        {
            if (greenBoxes[i].tag == "greenbox1")
            {
                allIn[0] = true;
            }
            if (greenBoxes[i].tag == "greenbox2")
            {
                allIn[1] = true;
            }
            if (greenBoxes[i].tag == "greenbox3")
            {
                allIn[2] = true;
            }
        }
        //as all boxes are in greenboxes so are detected and placed in the trigger it can set doit to true
        bool doIt = true;

        for (int i = 0; i < 3; i++)
        {
            if (!allIn[i]) //if its not true then dont trigger nothing it goes index 0, index 1, index 2 which are all <3 and checks if each one is false 
            {
                doIt = false;
                greenCheck = false;
            }
        }
        //as doit is true due to all boxes being deteced then we can trigger to make it purple 
        if (doIt)
        {

            color.material.SetColor("_Color", Color.green); //must have _Color otherwise it wont work 
            greenCheck = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {

        if (greenBoxes.IndexOf(collision.gameObject) > -1) //becuase we removed a box so that means the list is not full 
        {
            if (greenBoxes.Contains(collision.gameObject))
            {
                greenCheck = false;

                greenBoxes.Remove(collision.gameObject); //remove that box you moved out 
                color.material.SetColor("_Color", origonalColor); //must have _Color otherwise it wont work 

            }
        }
    }
} 
