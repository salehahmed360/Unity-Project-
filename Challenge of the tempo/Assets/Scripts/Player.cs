using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public CharacterController characterController; 
    // [SerializeField]
    public float movementSpeed = 12f; 
    public float jumpSpeed = 15;
    public float gravity = -10f; 

    public Vector3 velocity;
    public float jumpHeight;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded;

    public Movement Movement;
    public IUnityService UnityService = new UnityService(); 
     
    void Start()
    {

        characterController = GetComponent<CharacterController>();
        Movement = new Movement(movementSpeed);
    }

    //restart from level 1
    public void Restart()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(1);

        }
    }
    //return to the main menu 
    public void MainMenu()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene(0);

        }
    }
    void Update()
    {

        Restart();
        MainMenu();

        try
        { 
             GroundCheck(); //check we are touching ground to jump
        }catch(System.Exception e)
        {
            print("error"+e);
        }
          
        
        float x = UnityService.GetAxis("Horizontal");
        float z = UnityService.GetAxis("Vertical");  

        Vector3 movement = transform.right * x+ transform.forward * z;

        characterController.Move(Movement.CalMovemet(movement*movementSpeed*UnityService.GetDeltaTime())); //moves player by accessing Move function which comes with the character controller

        characterController.Move(Jump(jumpHeight,gravity) * UnityService.GetDeltaTime());

    } 
    public Vector3 Jump(float jumpHeight, float gravity) //jump using space which takes in the jump height and the gravity the player drops when jumper
    {

        if (Input.GetButtonDown("Jump") && isGrounded )
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * UnityService.GetDeltaTime();
        return velocity;
    }
    public void GroundCheck()
    {
        //create sphere based on the ground check position 
        // creates a radius based on groundDistance
        // using the groundMask such as ground layer which must be applied
        // to each thing in the environment 
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    } 

     

}
