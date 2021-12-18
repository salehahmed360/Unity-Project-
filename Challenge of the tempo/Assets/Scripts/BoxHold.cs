using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHold : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        this.GetComponent<Collider>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    private void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.layer == 9) { 
           // print("collided with: " + other.gameObject.name);
        
            if (Input.GetMouseButton(0))
            {
                 other.transform.position =this.transform.position;
                other.transform.parent = GameObject.Find("player").transform;
                other.transform.parent = GameObject.Find("hand").transform;
                //this.GetComponent<BoxCollider>().enabled = false;
                //this.rb.useGravity = false;
                other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            }
        }
    }
    private void OnCollisionExit(Collision other)
    {
       // print(other.gameObject.name);
            other.transform.parent = null;
            other.gameObject.GetComponent<Rigidbody>().useGravity = true;
      /*      this.GetComponent<Collider>().enabled = false;
        if (other.transform.parent == null) 
        {
            print("child is: "+other.gameObject.name);
            this.GetComponent<Collider>().enabled = true;
        }*/
        
    }
}
