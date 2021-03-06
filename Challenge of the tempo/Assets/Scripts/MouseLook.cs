using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivty = 100f;
    public Transform player;
    private float XRotation = 0f;
    void Start()
    { 
        Cursor.lockState = CursorLockMode.Locked; //locks cursor to the center of the screen 
        Cursor.visible = false; //makes the cursor invisible
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivty * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivty * Time.deltaTime;

        XRotation -= mouseY;
        XRotation = Mathf.Clamp(XRotation, -90 , 90f); //stops camera exceeding maximum

        transform.localRotation = Quaternion.Euler(XRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX );
    }
}
