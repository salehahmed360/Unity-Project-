using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController characterController; 
    // [SerializeField]
    public float movementSpeed = 12f; 
    public float jumpSpeed = 15;
    public float gravity = -10f; 

    Vector3 velocity;
    public float jumpHeight;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    public Movement Movement;
    public IUnityService UnityService = new UnityService();

     
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;//mouse locks to screen 
        Cursor.visible = false; //makes the cursor invisible

        characterController = GetComponent<CharacterController>();
        Movement = new Movement(movementSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        try
        { 
             GroundCheck();
        }catch(System.Exception e)
        {
            print("error"+e);
        }
          
        
        float x = UnityService.GetAxis("Horizontal");
        float z = UnityService.GetAxis("Vertical");  

        Vector3 movement = transform.right * x+ transform.forward * z;

        characterController.Move(Movement.CalMovemet(movement*movementSpeed*UnityService.GetDeltaTime()));

        characterController.Move(Jump(jumpHeight,gravity) * UnityService.GetDeltaTime());

    } 
    public Vector3 Jump(float jumpHeight, float gravity)
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
