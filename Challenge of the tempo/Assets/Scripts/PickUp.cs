using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public float pickupRange = 2; //how close we can pickup an object
    public Transform holdParent;
    private GameObject heldObj;
    public float moveForce = 250; //the speed the heldObj will move to the holdParent object

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * left mouse click should trigger to hold object and another click to let go 
         * checks the held object is null so if we are not already holding it it uses raycast based on the pickuprange set and calls the pickup object 
         * the pickupObject param has hit transform object such as the box and checks it has a rigid body and its layer 9 i.e. BOX and disable gravity and
         * sets its transform to the hand transform which is the holdParent
         * key point is it sets the pickObj which is passed in to heldObj which brings us back to heldObjec == null
         * 
         * if we are already holding the box as heldObj is not null anymore we can call dropObject method to drop object by setting gravity to true, parent and heldObj to null
         * 
         * if the heldObj is not null we check its distance by subtractint the holdParent which is the hand and the heldObj 
         * using moveDirection we add force to to the heldObj
         */
        if (Input.GetMouseButtonDown(0)){
            if (heldObj == null)
            { 
                RaycastHit hit;

                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange))
                {
                    PickUpObject(hit.transform.gameObject);
                }
            }
            else
            {
                DropObject();
            }
        }

        if(heldObj != null)
        {
            MoveObject();
        }
    }

    //update the heldObj position each frame
    void MoveObject()
    {
        if(Vector3.Distance(heldObj.transform.position, holdParent.position) > 0.2f)
        {
            Vector3 moveDirection =(holdParent.position - heldObj.transform.position);
            heldObj.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
        }
    }

    void PickUpObject(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>() && pickObj.gameObject.layer==9)
        {
            Rigidbody rigidObj = pickObj.GetComponent<Rigidbody>();
            rigidObj.useGravity = false;
            rigidObj.drag = 10;

            rigidObj.transform.parent = holdParent; //holdParent is now the parent of the pickObj 
            heldObj = pickObj; //heldObj is not null no more
        }
    }
    void DropObject()
    {
        Rigidbody heldRig = heldObj.GetComponent<Rigidbody>();
        heldRig.useGravity = true;
        heldRig.drag = 1;

        heldObj.transform.parent = null;
        heldObj = null;
    }
}
