using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene : MonoBehaviour
{
    public int scene;
    public GameObject FPcam;
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;
    public GameObject cam4;
    public GameObject cam5;

    // Start is called before the first frame update
    void Start()
    { 

  switch (scene) {
        case 1: 
                StartCoroutine(CutScene1());
                break;
        case 2: 
                StartCoroutine(CutScene2());
                break;
        case 3:
                StartCoroutine(CutScene3());
                break;
        case 4:
                StartCoroutine(CutScene4());
                break;
        case 5:
                StartCoroutine(CutScene5());
                break;

        } 
    }
     

    public IEnumerator CutScene1()
    { 
        cam1.SetActive(true);
        FPcam.SetActive(false);
        yield return new WaitForSeconds(3);
        FPcam.SetActive(true);
        cam1.SetActive(false);
        Destroy(gameObject); //destroy camera to stop cutscene from playing again
    }
    public IEnumerator CutScene2()
    {
        cam2.SetActive(true);
        FPcam.SetActive(false);
        yield return new WaitForSeconds(3);
        FPcam.SetActive(true);
        cam2.SetActive(false);
        Destroy(gameObject);
    }
    public IEnumerator CutScene3()
    {
        cam3.SetActive(true);
        FPcam.SetActive(false);
        yield return new WaitForSeconds(3);
        FPcam.SetActive(true);
        cam3.SetActive(false);
        Destroy(gameObject);
    }
    public IEnumerator CutScene4()
    {
        cam4.SetActive(true);
        FPcam.SetActive(false);
        yield return new WaitForSeconds(3);
        FPcam.SetActive(true);
        cam4.SetActive(false);
        Destroy(gameObject);
    }
    public IEnumerator CutScene5()
    {
        cam5.SetActive(true);
        FPcam.SetActive(false);
        yield return new WaitForSeconds(3);
        FPcam.SetActive(true);
        cam5.SetActive(false);
        Destroy(gameObject);
    }
}
