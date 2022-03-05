using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPointer : MonoBehaviour
{
    public GameObject pointer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {//allign the x and y of hand to the center canvas
        float x = pointer.transform.position.x;
        float y = pointer.transform.position.y;
        x = transform.position.x;
        y = transform.position.y;
        
    }
}
