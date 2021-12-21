using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sector1B : MonoBehaviour
{
    RedTrigger redtrigger, r;
    GreenTrigger greentrigger, g;
    BlueTrigger bluetrigger, b;
    PurpleTrigger purpletrigger, p;

    public GameObject parent; //using parent object to access its children to stop null pointer reference 
    private Animator animDoorLeft;
    private Animator animDoorRight;


    public bool openPortal = false; 

    void Start()
    {

        animDoorLeft = parent.transform.GetChild(0).GetComponent<Animator>();  //accessing first object in parent and accessing the animator component
        animDoorRight = parent.transform.GetChild(1).GetComponent<Animator>();

        redtrigger = GameObject.FindGameObjectWithTag("RedTrigger").GetComponent<RedTrigger>(); //accessing the script 
        greentrigger = GameObject.FindGameObjectWithTag("GreenTrigger").GetComponent<GreenTrigger>();
        bluetrigger = GameObject.FindGameObjectWithTag("BlueTrigger").GetComponent<BlueTrigger>();
        purpletrigger = GameObject.FindGameObjectWithTag("PurpleTrigger").GetComponent<PurpleTrigger>();

        r = redtrigger;
        g = greentrigger;
        b = bluetrigger;
        p = purpletrigger;

    }

    // Update is called once per frame
    void Update()
    {


        doorOpenening();
        doorClosing();

    }

    /* 
 * if its true sets the left and right door bool in animation to true 
 * this then open both doors 
 */
    public void doorOpenening()
    {
        if (r.redCheck == true && p.purpleCheck == true && g.greenCheck == true && b.blueCheck == true)
        {
            openPortal = true;
            animDoorLeft.SetBool("LDisOpening", true);
            animDoorRight.SetBool("RDisOpening", true);

        }
    }

    /*
     * checking if all boxes check is false or either
     * the then puts both doors to closing state as its false
     */
    public void doorClosing()
    {
        if (r.redCheck == false || p.purpleCheck == false || g.greenCheck == false || b.blueCheck == false)
        {
            openPortal = false;
            animDoorLeft.SetBool("LDisOpening", false);
            animDoorRight.SetBool("RDisOpening", false);
        }
    }
}
