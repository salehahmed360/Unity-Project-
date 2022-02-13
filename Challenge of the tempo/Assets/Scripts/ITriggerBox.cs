using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * ITriggerBox interface has a list boxes which all triggers use 
 */
public interface ITriggerBox
{

    List<GameObject> Boxes { get; set; }

    bool GetIsActive();
    void SetTriggerActive(bool active);

    void AddBox(GameObject box, string tagbox1, string tagbox2, string tagbox3);

    void Remove(GameObject box);

    void ActivateTrigger(bool doIt, Renderer renderer, Color color);

    bool CheckAllBoxesIn(bool doIt, bool[]allin);

    void CheckTagInList(bool []allin, string tag1, string tag2, string tag3);
}

public class TriggerBox : ITriggerBox
{

    public List<GameObject> Boxes { get; set; }

    public bool triggerActive;

    public void SetTriggerActive(bool active)
    {
        triggerActive = active;
    }
    public bool GetIsActive()
    {
        return triggerActive;
    }
    public TriggerBox()
    {
        Boxes = new List<GameObject>();  //instantiates  boxes list
    }
    public void AddBox(GameObject box, string tagbox1, string tagbox2, string tagbox3)
    {

        if (box.gameObject.layer == 9 && Boxes.Count < 4) //checks if its a box layer and its less than three
        {
            if (box.gameObject.tag == tagbox1 || box.gameObject.tag == tagbox2 || box.gameObject.tag == tagbox3) //if its in any of the tags specified it gets added in
            {
                Boxes.Add(box);
            }

        }
    }

    public void ActivateTrigger(bool doIt, Renderer renderer, Color color)
    {
        if (doIt)
        {
            renderer.material.SetColor("_Color", color); //changes to the selected colour when all boxes in list 
            triggerActive = true;
        }
    }

    public bool CheckAllBoxesIn(bool doIt, bool[] allin)
    {
        for (int i = 0; i < 3; i++)
        {
            if (!allin[i]) //if its not true then dont trigger nothing it goes index 0, index 1, index 2 which are all <3 and checks if each one is false 
            {
                doIt = false;
                triggerActive = false;
            }
        }
        return doIt;
    }

    public void CheckTagInList(bool[] allin, string tag1, string tag2, string tag3)//checks with tags given with whats in the list and sets array indexes to true
    {
        for (int i = 0; i < Boxes.Count; i++)
        {
            if (Boxes[i].tag == tag1)
            {
                allin[0] = true;
            }
            if (Boxes[i].tag == tag2)
            {
                allin[1] = true;
            }
            if (Boxes[i].tag == tag3)
            {
                allin[2] = true;

            }
        }
    }

    public void Remove(GameObject box)
    {
        Boxes.Remove(box);
    }
}