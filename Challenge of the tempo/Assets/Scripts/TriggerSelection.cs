using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * purpose of this class it to reduce repition in all the sector classes
 * each method returns the trigger class to check if the triggers are activated by checking its object tag and getting its component 
 */
public class TriggerSelection
{ 

    public RedTrigger GetRedTrigger()
    {
        return GameObject.FindGameObjectWithTag("RedTrigger").GetComponent<RedTrigger>(); //accessing the script 
    }
    public GreenTrigger GetGreenTrigger()
    {
        return GameObject.FindGameObjectWithTag("GreenTrigger").GetComponent<GreenTrigger>();
    }
    public BlueTrigger GetBlueTrigger()
    {
        return GameObject.FindGameObjectWithTag("BlueTrigger").GetComponent<BlueTrigger>();
    }
    public PurpleTrigger GetPurpleTrigger()
    {
        return GameObject.FindGameObjectWithTag("PurpleTrigger").GetComponent<PurpleTrigger>();
    }


}
