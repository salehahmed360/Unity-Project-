using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPortal : MonoBehaviour
{


    //outputPortal object
    public GameObject outputPortal;
    // Start is called before the first frame update  
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //detects the box placed on input portal
     void OnCollisionEnter(Collision collision)
    {

        teleportBox(collision.gameObject);

    }
    //checks its portal box and teleports it into the center of the outputPortal
    void teleportBox(GameObject box)
    {
        if (box.gameObject.CompareTag("teleportBox") && box != null)
        {
            //get the center of the output portal to move the box into the center 
            var center = outputPortal.GetComponent<Renderer>().bounds.center;
            box.transform.position = center;
        }
    }

}
