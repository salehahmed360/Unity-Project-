using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpen : MonoBehaviour
{

    public Transform door1;
    public Transform door2;
    public doorTrigger doorTrigger;

    //opens left
    Vector3 openDoor1 = new Vector3(0.4f, 0.0f, 0.0f); //speed which it goes up per frame
    [SerializeField]
    public float door1Stop = -2.2f;
    Vector3 door1Start; //stores the original position of the door

    //open right
    Vector3 openDoor2 = new Vector3(-0.4f, 0.0f, 0.0f); //speed which it goes up per frame
    public float door2Stop = -6.8f;
    Vector3 door2Start; //stores the original position of the door


    void Start()
    {
        doorTrigger = GameObject.FindGameObjectWithTag("doorTrigger").GetComponent<doorTrigger>();
        door1Start = new Vector3(door1.position.x, 0f, 0f);
        door2Start = new Vector3(door2.position.x, 0f, 0f);
        print(door2.position.x);
    }

    // Update is called once per frame
    void Update()
    {
        //print(doorTrigger.doorStatues);
        print(door2.position.x);
        if (doorTrigger.doorStatues == true)
        {
            if (door1.position.x < door1Stop)
            {
                door1.position += openDoor1 * Time.deltaTime;
            }
        }
        else
        {

            if (door1.position.x >= door1Start.x)
            {
                door1.position -= openDoor1 * Time.deltaTime;
            } 
        }



        if (doorTrigger.doorStatues == true)
        {
            if (door2.position.x > door2Stop)
            {
                door2.position += openDoor2 * Time.deltaTime;
            }
        }
        else
        {

            if (door2.position.x <= door2Start.x)
            {
                door2.position -= openDoor2 * Time.deltaTime;
            }
        }
    }
}
 
