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
    public float turnspeed = 10.0f;
    public float speed = 10.0F;
    public float jumpspeed = 10.0F;
    public float gravSpeed = 10.0F;
    bool grounded;
    private GameObject playerSpawn;
   
   
    void Start () {
        rg = GetComponent <Rigidbody> ();
        animator = GetComponent <Animator> ();
        playerSpawn = GameObject.Find("playerSpawn");
        transform.position = playerSpawn.transform.position;
    }
   
   
    void Update () {
        if (moveDirection == Vector3.zero) {
            animator.SetBool("Run",false);
        }
        else {
            runSound.Play();
            animator.SetBool("Run",true);
            
        }
        

        float translation = Input.GetAxis ("Vertical") * speed;
        float strafe = Input.GetAxis ("Horizontal") * speed;
        translation *= (Time.deltaTime);
        strafe *= (Time.deltaTime);
        moveDirection = new Vector3(translation, 0, strafe);
        transform.Translate (strafe, 0, translation, Camera.main.transform);
        grounded = Physics.CheckSphere(GroundCheck.transform.position, .2f, LayerMask.GetMask("Ground"));

        if (Input.GetKey (KeyCode.Space) && grounded) {
            Jump();
        }
        
       
    }
    void Jump(){
        rg.velocity = new Vector3(rg.velocity.x, jumpspeed, 0);
        jumpSound.Play();
    }
    
    void FixedUpdate(){
        Vector3 dir = Vector3.zero;
 
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");

        Vector3 camDirection = Camera.main.transform.rotation * dir;
        Vector3 targetDirection = new Vector3(camDirection.x, 0, camDirection.z);//make the player look in the direction of the camera is facing
            
        if (dir != Vector3.zero) {//make the rotation smoother by using the slerp and crossing the rotation of the character with the direction of the camera
            transform.rotation = Quaternion.Slerp(
            transform.rotation,
            Quaternion.LookRotation(targetDirection),
            Time.deltaTime * turnspeed
            );
        }
        // if (rg.velocity.y < .5f *jumpspeed || !(Input.GetKey (KeyCode.Space))){
        //     rg.velocity =  Time.fixedDeltaTime * Physics.gravity.y * gravSpeed * Vector3.up *7;
        //     //Time.fixedDeltaTime Vector3.up *
        // }
    }
}
