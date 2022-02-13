using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSelection
{ 

    public RedTrigger GetRedTrigger()
    {
        return GameObject.FindGameObjectWithTag("RedTrigger").GetComponent<RedTrigger>(); //accessing the script ;
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
