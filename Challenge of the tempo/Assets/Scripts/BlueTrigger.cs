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

    private string tag1;
    private string tag2;
    private string tag3;
    void Start()
    {
        blueBoxes = new TriggerBox();

        tag1 = "bluebox1";
        tag2 = "bluebox2";
        tag3 = "bluebox3";

        allIn = new bool[3]; //each box is assigned true or false if all in blueBoxes
        color = gameObject.GetComponent<Renderer>(); //access box colour
        origonalColor = color.material.color; //gets the original colour on the box and stores it in this variable
    }
    private void Update()
    {
        if (blueBoxes.GetIsActive() == true)
        {
            blueCheck = true;
        }
        else
        {
            blueCheck = false;
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        blueBoxes.AddBox(collision.gameObject, "bluebox1", "bluebox2", "bluebox3");

        for (int i = 0; i < 3; i++)
        {
            allIn[i] = false;
        }

        blueBoxes.CheckTagInList(allIn, tag1, tag2, tag3);
        bool doIt = true;  //if all boxes are in blueboxes so are detected and placed in the trigger it can set doit to true
        doIt = blueBoxes.CheckAllBoxesIn(doIt, allIn);
        blueBoxes.ActivateTrigger(doIt, color, Color.blue);  //if doit is true due to all boxes being deteced then we can trigger to make it blue 

    }

    private void OnTriggerExit(Collider collision)
    {

        if (blueBoxes.Boxes.IndexOf(collision.gameObject) > -1) //becuase we removed a box so that means the list is not full 
        {
            if (blueBoxes.Boxes.Contains(collision.gameObject))
            {
                blueBoxes.SetTriggerActive(false);
                blueBoxes.Remove(collision.gameObject); //remove that box you moved out 
                color.material.SetColor("_Color", origonalColor); //must have _Color otherwise it wont work 

            }
        }
    }
}
