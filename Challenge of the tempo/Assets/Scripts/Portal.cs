using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    // Start is called before the first frame update
    Sector1B sector1b;
    public int index =1;
    void Start()
    {
        sector1b = GameObject.FindGameObjectWithTag("sector1b").GetComponent<Sector1B>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            if (sector1b.openPortal == true) 
            {
                SceneManager.LoadScene(index);
            }
        }
    }
}
