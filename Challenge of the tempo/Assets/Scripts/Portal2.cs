using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal2 : MonoBehaviour
{
    // Start is called before the first frame update
    Sector2B sector2b;
    //public int index = 0;
    public GameComplete gamecomplete;
    void Start()
    {
        sector2b = GameObject.FindGameObjectWithTag("sector2b").GetComponent<Sector2B>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            if (sector2b.levelComplete == true)
            {
                Time.timeScale = 0;
                gamecomplete.GameCompletion();
                //SceneManager.LoadScene(index);
            }
        }
    }
}