using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleTrigger : MonoBehaviour
{
    public ITriggerBox purpleBoxes;
    public bool[] allIn;
    public Color origonalColor;
    public Renderer color;
    public bool purpleCheck;

    private string tag1;
    private string tag2;
    private string tag3;
    void Start()
    {

        purpleBoxes = new TriggerBox();

        tag1 = "purplebox1";
        tag2 = "purplebox2";
        tag3 = "purplebox3";

        allIn = new bool[3]; //each box is assigned true or false if all in purpleBoxes
        color = gameObject.GetComponent<Renderer>(); //access box colour
        origonalColor = color.material.color; //gets the original colour on the box and stores it in this variable
    }
    private void Update()
    {
        if (purpleBoxes.GetIsActive() == true)
        {
            purpleCheck = true; 
        }
        else
        {
            purpleCheck = false;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        purpleBoxes.AddBox(collision.gameObject, "purplebox1", "purplebox2", "purplebox3");

        for (int i = 0; i < 3; i++)
        {
            allIn[i] = false;
        }
        purpleBoxes.CheckTagInList(allIn, tag1, tag2, tag3);
        bool doIt = true;        //as all boxes are in purpleboxes so are detected and placed in the trigger it can set doit to true
        doIt = purpleBoxes.CheckAllBoxesIn(doIt, allIn);
        purpleBoxes.ActivateTrigger(doIt, color, Color.magenta);     //as doit is true due to all boxes being deteced then we can trigger to make it purple 
    }

    private void OnTriggerExit(Collider collision)
    {

        if (purpleBoxes.Boxes.IndexOf(collision.gameObject) > -1) //becuase we removed a box so that means the list is not full 
        {
            if (purpleBoxes.Boxes.Contains(collision.gameObject))
            {
                purpleBoxes.SetTriggerActive(false);
                purpleBoxes.Remove(collision.gameObject); //remove that box you moved out 
                color.material.SetColor("_Color", origonalColor); //must have _Color otherwise it wont work 

            }
        }
    }
}
