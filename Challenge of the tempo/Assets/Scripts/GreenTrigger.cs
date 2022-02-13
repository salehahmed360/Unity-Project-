using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenTrigger : MonoBehaviour
{
    public ITriggerBox greenBoxes;
    public bool[] allIn;
    public Color origonalColor;
    public Renderer color;
    public bool greenCheck;

    private string tag1;
    private string tag2;
    private string tag3;
    void Start()
    {
        greenBoxes = new TriggerBox();//instantiates the triggerbox class to access list and addbox function

        tag1 = "greenbox1";
        tag2 = "greenbox2";
        tag3 = "greenbox3";

        allIn = new bool[3]; //each box is assigned true or false if all in greenBoxes
        color = gameObject.GetComponent<Renderer>(); //access box colour
        origonalColor = color.material.color; //gets the original colour on the box and stores it in this variable
    }
    private void Update()
    {
        if (greenBoxes.GetIsActive() == true)
        {
            greenCheck = true;
        }
        else
        {
            greenCheck = false;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        greenBoxes.AddBox(collision.gameObject, tag1, tag2, tag3);

        for (int i = 0; i < 3; i++)
        {
            allIn[i] = false;
        }
        greenBoxes.CheckTagInList(allIn, tag1, tag2, tag3);
        bool doIt = true;//if all boxes are in greenboxes so are detected and placed in the trigger it can set doit to true
        doIt = greenBoxes.CheckAllBoxesIn(doIt, allIn);
        greenBoxes.ActivateTrigger(doIt, color, Color.green); //if doit is true due to all boxes being deteced then we can trigger to make it purple 

    }

    private void OnTriggerExit(Collider collision)
    {
        if (greenBoxes.Boxes.IndexOf(collision.gameObject) > -1) //becuase we removed a box so that means the list is not full 
        {
            if (greenBoxes.Boxes.Contains(collision.gameObject))
            {
                greenBoxes.SetTriggerActive(false);
                greenBoxes.Remove(collision.gameObject); //remove that box you moved out 
                color.material.SetColor("_Color", origonalColor); //must have _Color otherwise it wont work 

            }
        }
    }
} 
