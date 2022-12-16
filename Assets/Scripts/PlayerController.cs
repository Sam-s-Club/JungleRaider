using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rg;
    private Animator animator;
    public GameObject GroundCheck;
    private Vector3 moveDirection;
    public AudioSource runSound;
    public AudioSource jumpSound;

    public float turnspeed = 15.0f;
    public float movementSpeed = 7.0F;
    public float jumpspeed = 14.0F;
    public float gravSpeed = 15.0F;
    public float terminalVelocity = 10.0F;
    public float diminishingMultiplier = 0.75f;

    public float jumpDelay = 0.25f;
    public float jumpTolerance = 0.6f;

    bool grounded;
    
    //get the animator and the rigidbody
    void Start () 
    {
        rg = GetComponent <Rigidbody> ();
        animator = GetComponent <Animator> ();
    }
    
    //checking keys, doing movement and animation
    void Update () 
    {
        // Set animation according to movement speed
        if (moveDirection == Vector3.zero)
        {
            animator.SetBool("Run",false);
        }
        else 
        {
            runSound.Play();
            animator.SetBool("Run",true);
        }

        // check terminal velocity
        if (rg.velocity.y < -terminalVelocity)
        {
            rg.velocity = new Vector3(rg.velocity.x, -terminalVelocity, 0);
        }

        // Diminishes the velocity if going up and use deltaTime to make it framerate independent
        if (rg.velocity.y > 0)
        {
            rg.velocity = new Vector3(rg.velocity.x, rg.velocity.y - (rg.velocity.y * diminishingMultiplier * Time.deltaTime), 0);
        }

        // acclerates down if falling enables fast falling
        if (rg.velocity.y < 0)
        {
            rg.velocity = new Vector3(rg.velocity.x, rg.velocity.y - (gravSpeed * Time.deltaTime), 0);
        }
        

        //movement handeling
        float translation = Input.GetAxis ("Vertical") * movementSpeed;
        float strafe = Input.GetAxis ("Horizontal") * movementSpeed;

        // manage speed
        translation *= Time.deltaTime;
        strafe *= Time.deltaTime;
         
        // move the character
        transform.Translate (strafe, 0, translation, Camera.main.transform);
        moveDirection = new Vector3(translation, 0, strafe);

        // check if the player is on the ground        
        grounded = Physics.CheckSphere(GroundCheck.transform.position, .2f, LayerMask.GetMask("Ground"));//checking if character will jump
        
        
        if (grounded && Input.GetButtonDown("Jump")) 
        {
            // check how long the player pressed until jumpDelay and change the jump speed accordingly
            float jumpTime = Mathf.Clamp01(Input.GetAxis("Jump") / jumpDelay);
            Jump();
        }

    }

    // check how close the player is to the ground
    private bool CloseEnoughToGround()
    {
        return Physics.CheckSphere(GroundCheck.transform.position, jumpTolerance, LayerMask.GetMask("Ground"));
    }

    //jump function for character and handles sound
    void Jump()
    {
        rg.velocity = new Vector3(rg.velocity.x, jumpspeed, 0);
        jumpSound.Play();
    }
    
    //handle the camera, look direction and etc.
    void FixedUpdate()
    {
        Vector3 dir = Vector3.zero;
        
        // Mouse look
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");
        
        Vector3 camDirection = Camera.main.transform.rotation * dir;
        Vector3 targetDirection = new Vector3(camDirection.x, 0, camDirection.z);//make the player look in the direction of the camera is facing
            
        if (dir != Vector3.zero) //make the rotation smoother by using the slerp and crossing the rotation of the character with the direction of the camera
        {
            transform.rotation = Quaternion.Slerp(
            transform.rotation,
            Quaternion.LookRotation(targetDirection),
            Time.deltaTime * turnspeed
            );
        }
    }
}
