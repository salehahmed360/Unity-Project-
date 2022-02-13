using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RedTrigger : MonoBehaviour
{
    
    public bool[] allIn; 
    public Color origonalColor;
    public Renderer color;
    public bool redCheck;
    public ITriggerBox redBoxes;

    private string tag1;
    private string tag2;
    private string tag3;
    void Start()
    {
        redBoxes = new TriggerBox(); //instantiates the triggerbox class to access list and addbox function

        tag1 = "redbox1";
        tag2 = "redbox2";
        tag3 = "redbox3";
        
        allIn = new bool[3]; //each box is assigned true or false if all in redBoxes
        color = gameObject.GetComponent<Renderer>(); //access box colour
        origonalColor = color.material.color; //gets the original colour on the box and stores it in this variable
    }
    private void Update()
    {
        if (redBoxes.GetIsActive() == true)
        {
            redCheck = true;
        }
        else
        {
            redCheck = false;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        redBoxes.AddBox(collision.gameObject, tag1, tag2, tag3);//sets all to false till otherwise changed to true it keeps updating so if its in redboxes list and has matching tag then they are changed to all true unitl one is out it becomes false
        
        for (int i = 0; i < 3; i++)
        {
            allIn[i] = false;
        }

        redBoxes.CheckTagInList(allIn, tag1, tag2, tag3);
        bool doIt = true;  //if all boxes are in redboxes so are detected and placed in the trigger it can set doit to true
        doIt = redBoxes.CheckAllBoxesIn(doIt, allIn);
        redBoxes.ActivateTrigger(doIt, color, Color.red);
    }
    private void OnTriggerExit(Collider collision)
    {

        if (redBoxes.Boxes.IndexOf(collision.gameObject) > -1) //becuase we removed a box so that means the list is not full 
        {
            if (redBoxes.Boxes.Contains(collision.gameObject))
            {
                redBoxes.SetTriggerActive(false);
                redBoxes.Remove(collision.gameObject); //remove that box you moved out 
                color.material.SetColor("_Color", origonalColor); //must have _Color otherwise it wont work 

            }
        }
    } 
}

