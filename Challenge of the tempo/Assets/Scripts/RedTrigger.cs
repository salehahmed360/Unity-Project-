using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTrigger : MonoBehaviour
{
    public List<GameObject> redBoxes;
    public bool[] allIn;
    public Color origonalColor;
    public Renderer color;
    public bool redCheck;// = false; 
    void Start()
    {

        redBoxes = new List<GameObject>(); //store the collided boxes
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

            redBoxes.Add(collision.gameObject); //only adds one
        }
        //sets all to false till otherwise changed to true it keeps updating so if its in redboxes list and has matching tag then they are changed to all true unitl one is out it becomes false
        for (int i = 0; i < 3; i++)
        {
            allIn[i] = false;
        }
        for (int i = 0; i < redBoxes.Count; i++)
        {
            if (redBoxes[i].tag == "redbox1")
            {
                allIn[0] = true;
            }
            if (redBoxes[i].tag == "redbox2")
            {
                allIn[1] = true;
            }
            if (redBoxes[i].tag == "redbox3")
            {
                allIn[2] = true;
            }
        }
        //as all boxes are in redboxes so are detected and placed in the trigger it can set doit to true
        bool doIt = true;

        for (int i = 0; i < 3; i++)
        {
            if (!allIn[i]) //if its not true then dont trigger nothing it goes index 0, index 1, index 2 which are all <3 and checks if each one is false 
            {
                doIt = false;
                redCheck = false;
            }
        }
        //as doit is true due to all boxes being deteced then we can trigger to make it red 
        if (doIt)
        {

            color.material.SetColor("_Color", Color.red); //must have _Color otherwise it wont work 
            redCheck = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {

        if (redBoxes.IndexOf(collision.gameObject) > -1) //becuase we removed a box so that means the list is not full 
        {
            if (redBoxes.Contains(collision.gameObject))
            {
                redCheck = false;

                redBoxes.Remove(collision.gameObject); //remove that box you moved out 
                color.material.SetColor("_Color", origonalColor); //must have _Color otherwise it wont work 

            }
        }
    }
}

