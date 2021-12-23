using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeTrigger : MonoBehaviour
{
    private GameObject box;
    private Color origonalColor;
    private Renderer color;
    public GameObject bridge;
    private Collider collider;
    // Start is called before the first frame update
    void Start()
    {
        color = bridge.GetComponent<Renderer>(); 
        origonalColor = color.material.color;
         
        collider = bridge.GetComponent<Collider>();
        collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer==9 && other !=null)
        {
            collider.enabled = true; 
            color.material.SetColor("_Color", Color.green); //sets the colour to green if the box is placed on the trigger
        }
    }

    private void OnTriggerExit(Collider other)
    {
        collider.enabled = false;
        color.material.SetColor("_Color", origonalColor); //sets to original colour if the box is removed
    }
}
