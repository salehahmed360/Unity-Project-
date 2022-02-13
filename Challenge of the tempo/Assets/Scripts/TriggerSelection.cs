using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSelection : MonoBehaviour
{
    private RedTrigger redTrigger;
    private GreenTrigger greenTrigger;
    private BlueTrigger blueTrigger;
    private PurpleTrigger purpleTrigger;

    // Start is called before the first frame update
    void Start()
    {
        redTrigger = GameObject.FindGameObjectWithTag("RedTrigger").GetComponent<RedTrigger>(); //accessing the script 
        greenTrigger = GameObject.FindGameObjectWithTag("GreenTrigger").GetComponent<GreenTrigger>();
        blueTrigger = GameObject.FindGameObjectWithTag("BlueTrigger").GetComponent<BlueTrigger>();
        purpleTrigger = GameObject.FindGameObjectWithTag("PurpleTrigger").GetComponent<PurpleTrigger>();
    }

    public RedTrigger GetRedTrigger()
    {
        return redTrigger;
    }
    public GreenTrigger GetGreenTrigger()
    {
        return greenTrigger;
    }
    public BlueTrigger GetBlueTrigger()
    {
        return blueTrigger;
    }
    public PurpleTrigger GetPurpleTrigger()
    {
        return purpleTrigger;
    }


}
