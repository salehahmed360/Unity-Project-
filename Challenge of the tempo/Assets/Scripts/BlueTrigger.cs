using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueTrigger : MonoBehaviour
{
    public ITriggerBox blueBoxes;
    public bool[] allIn;
    public Color origonalColor;
    public Renderer color;
    public bool blueCheck;
    void Start()
    {
        blueBoxes = new TriggerBox();
        allIn = new bool[3]; //each box is assigned true or false if all in greenBoxes
        color = gameObject.GetComponent<Renderer>(); //access box colour
        origonalColor = color.material.color; //gets the original colour on the box and stores it in this variable
    }
    private void OnTriggerEnter(Collider collision)
    {
        blueBoxes.AddBox(collision.gameObject, "bluebox1", "bluebox2", "bluebox3");

        for (int i = 0; i < 3; i++)
        {
            allIn[i] = false;
        }
        CheckTagInList();
        bool doIt = true;  //if all boxes are in blueboxes so are detected and placed in the trigger it can set doit to true
        doIt = CheckAllBoxesIn(doIt);
        ActivateTrigger(doIt);  //if doit is true due to all boxes being deteced then we can trigger to make it blue 

    }

    private void ActivateTrigger(bool doIt)
    {
        if (doIt)
        {

            color.material.SetColor("_Color", Color.blue); //must have _Color otherwise it wont work 
            blueCheck = true;
        }
    }

    private bool CheckAllBoxesIn(bool doIt)
    {
        for (int i = 0; i < 3; i++)
        {
            if (!allIn[i]) //if its not true then dont trigger nothing it goes index 0, index 1, index 2 which are all <3 and checks if each one is false 
            {
                doIt = false;
                blueCheck = false;
            }
        }

        return doIt;
    }

    private void CheckTagInList()
    {
        for (int i = 0; i < blueBoxes.Boxes.Count; i++)
        {
            if (blueBoxes.Boxes[i].tag == "bluebox1")
            {
                allIn[0] = true;
            }
            if (blueBoxes.Boxes[i].tag == "bluebox2")
            {
                allIn[1] = true;
            }
            if (blueBoxes.Boxes[i].tag == "bluebox3")
            {
                allIn[2] = true;
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {

        if (blueBoxes.Boxes.IndexOf(collision.gameObject) > -1) //becuase we removed a box so that means the list is not full 
        {
            if (blueBoxes.Boxes.Contains(collision.gameObject))
            {
                blueCheck = false;

                blueBoxes.Boxes.Remove(collision.gameObject); //remove that box you moved out 
                color.material.SetColor("_Color", origonalColor); //must have _Color otherwise it wont work 

            }
        }
    }
}
