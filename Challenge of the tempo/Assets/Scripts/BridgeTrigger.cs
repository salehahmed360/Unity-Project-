using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeTrigger : MonoBehaviour
{
    private GameObject box;
    private Color origonalColor;
    private Renderer color;
    public GameObject bridge;
    private Collider bridgeCollider;

    public GameObject cutScene;
    // Start is called before the first frame update
    void Start()
    {
        color = bridge.GetComponent<Renderer>(); //accessing the bridge colour
        origonalColor = color.material.color; //store bridge original colour

        bridgeCollider = bridge.GetComponent<Collider>();
        bridgeCollider.enabled = false; //sets collision to false which stops player from crossing
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("doorBox") || other.CompareTag("teleportBox"))//only doorbox and teleportbox can be used to trigger bridge 
        {
            bridgeCollider.enabled = true; //allows player to wall on bridge
            color.material.SetColor("_Color", Color.green); //sets the colour to green if the box is placed on the trigger
            if (cutScene != null)
            {
                cutScene.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        bridgeCollider.enabled = false; //if box removed it deactivates bridge
        color.material.SetColor("_Color", origonalColor); //sets to original colour if the box is removed
    }
}
