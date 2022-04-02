using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sector1A : MonoBehaviour
{
    private TriggerSelection trigger;

    public GameObject parent; //using parent object to access its children to stop null pointer reference 
    private Animator animDoorLeft;
    private Animator animDoorRight;

    private int playing=1;
    public AudioSource openDoor; //audio sound for opening door
    public AudioSource closeDoor; //audio sound for closing door

    public GameObject cutScene;

    void Start()
    {
        trigger = new TriggerSelection();

        animDoorLeft = parent.transform.GetChild(0).GetComponent<Animator>();  //accessing first object in parent and accessing the animator component
        animDoorRight = parent.transform.GetChild(1).GetComponent<Animator>(); 

    }

    // Update is called once per frame
    void Update()
    { 
            DoorOpenening();
            DoorClosing();
    }

    /* 
 * if its true sets the left and right door bool in animation to true 
 * this then open both doors 
 */
    public void DoorOpenening()
    {
        if (trigger.GetRedTrigger().redCheck == true && trigger.GetPurpleTrigger().purpleCheck == true && trigger.GetGreenTrigger().greenCheck == true)
        { 
            if (playing ==1)
            {
                openDoor.Play();
                if (cutScene != null)
                {
                    cutScene.SetActive(true);
                }
                playing = 0; 
            } 

            animDoorLeft.SetBool("LDisOpening", true);
            animDoorRight.SetBool("RDisOpening", true);

        }
    }

    /*
     * checking if all boxes check is false or either
     * the then puts both doors to closing state as its false
     */
    public void DoorClosing()
    {
        if (trigger.GetRedTrigger().redCheck == false || trigger.GetPurpleTrigger().purpleCheck == false || trigger.GetGreenTrigger().greenCheck == false)
        {
            if (playing == 0)
            {
                openDoor.Play();
                playing = 1;
            }

            animDoorLeft.SetBool("LDisOpening", false);
            animDoorRight.SetBool("RDisOpening", false);
        }
    }

}
