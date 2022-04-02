using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
   
    private Sector1B sector1b; //sector b class to check if all triggers are active in the second section
    public int index =1; //scene index

    private AudioSource portalAudio;//portal audio once player crosses the portal 
    void Start()
    {

        portalAudio = gameObject.GetComponent<AudioSource>();
        sector1b = GameObject.FindGameObjectWithTag("sector1b").GetComponent<Sector1B>();//accesses the Sector1B without needing its object
    }
     

    public void OnTriggerEnter(Collider other)
    {
        //check if its player then checks if all triggers are active which opens the portal 
        if (other.CompareTag("player"))
        {
            if (sector1b.openPortal == true) 
            {
                StartCoroutine(DelayScreenAction(1f));
            }
        }
    }
    public IEnumerator DelayScreenAction(float time)
    {
        portalAudio.Play();
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(index);
    }
    }
