using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene2 : MonoBehaviour
{
    public int scene;  //what camera will be displayed from below
    public GameObject FPcam;//player main camera
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;
    public GameObject cam4;
    public GameObject cam5;
    public GameObject cam6;
    public GameObject cam7;
    public GameObject cam8;
     
    void Start()
    {

        switch (scene)
        {
            case 1:
                StartCoroutine(CutScene_1());
                break;
            case 2:
                StartCoroutine(CutScene_2());
                break;
            case 3:
                StartCoroutine(CutScene_3());
                break;
            case 4:
                StartCoroutine(CutScene_4());
                break;
            case 5:
                StartCoroutine(CutScene_5());
                break;  
            case 6:
                StartCoroutine(CutScene_6());
                break;  
            case 7:
                StartCoroutine(CutScene_7());
                break;
            case 8:
                StartCoroutine(CutScene_8());
                break;

        }
    }


    public IEnumerator CutScene_1()
    {
        cam1.SetActive(true);
        FPcam.SetActive(false);
        yield return new WaitForSeconds(3);
        FPcam.SetActive(true);
        cam1.SetActive(false);
        Destroy(gameObject); //destroy camera to stop cutscene from playing again
    }
    public IEnumerator CutScene_2()
    {
        cam2.SetActive(true);
        FPcam.SetActive(false);
        yield return new WaitForSeconds(3);
        FPcam.SetActive(true);
        cam2.SetActive(false);
        Destroy(gameObject);
    }
    public IEnumerator CutScene_3()
    {
        cam3.SetActive(true);
        FPcam.SetActive(false);
        yield return new WaitForSeconds(3);
        FPcam.SetActive(true);
        cam3.SetActive(false);
        Destroy(gameObject);
    }
    public IEnumerator CutScene_4()
    {
        cam4.SetActive(true);
        FPcam.SetActive(false);
        yield return new WaitForSeconds(3);
        FPcam.SetActive(true);
        cam4.SetActive(false);
        Destroy(gameObject);
    }
    public IEnumerator CutScene_5()
    {
        cam5.SetActive(true);
        FPcam.SetActive(false);
        yield return new WaitForSeconds(3);
        FPcam.SetActive(true);
        cam5.SetActive(false);
        Destroy(gameObject);
    }   
    public IEnumerator CutScene_6()
    {
        cam6.SetActive(true);
        FPcam.SetActive(false);
        yield return new WaitForSeconds(3);
        FPcam.SetActive(true);
        cam6.SetActive(false);
        Destroy(gameObject);
    }   public IEnumerator CutScene_7()
    {
        cam7.SetActive(true);
        FPcam.SetActive(false);
        yield return new WaitForSeconds(3);
        FPcam.SetActive(true);
        cam7.SetActive(false);
        Destroy(gameObject);
    } public IEnumerator CutScene_8()
    {
        cam8.SetActive(true);
        FPcam.SetActive(false);
        yield return new WaitForSeconds(3);
        FPcam.SetActive(true);
        cam8.SetActive(false);
        Destroy(gameObject);
    }
}
