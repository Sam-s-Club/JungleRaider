using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2_mod : MonoBehaviour
{
    private Rigidbody rg;
    public float speed = 10.0F;
    public float jumpspeed = 10.0F;
    public float turnspeed = 10.0f;
    public float gravSpeed = 10.0F;
    public bool grounded = true;
    public bool jump = false;
    Animator m_Animator;
    private GameObject playerSpawn;
    
    //initializing all the components for the player and then spawning them in the correct position
    void Start () {
        rg = GetComponent <Rigidbody> ();
        m_Animator = gameObject.GetComponent<Animator>();
        playerSpawn = GameObject.Find("PlayerSpawn");
        transform.position = playerSpawn.transform.position;
    }
   
   //checking to see if the space key was pressed
    void Update () {
        if (Input.GetKey (KeyCode.Space) ) {
            jump = true;
        }   
    }
    
    void FixedUpdate(){
        //if the player pressed space and they were on the ground
        if(jump && grounded){
            grounded = false;
            m_Animator.SetTrigger("Jump");
            rg.velocity = new Vector3(rg.velocity.x, jumpspeed, rg.velocity.z);//add new velocity to the rigidbody with z and x velocity remaining the same
        }
        else{
            Vector3 dir = Vector3.zero;
 
            dir.x = Input.GetAxis("Horizontal");
            dir.z = Input.GetAxis("Vertical");
            
            if(dir.x != 0 || dir.z != 0){//trigger animator to set the animation if moving along x or z axis
                m_Animator.SetBool("Run",true);
            }
            else{
                m_Animator.SetBool("Run",false);
            }

            Vector3 camDirection = Camera.main.transform.rotation * dir;
            Vector3 targetDirection = new Vector3(camDirection.x, 0, camDirection.z);//make the player look in the direction of the camera is facing
                
            if (dir != Vector3.zero) {//make the rotation smoother by using the slerp and crossing the rotation of the character with the direction of the camera
                transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(targetDirection),
                Time.deltaTime * turnspeed
                );
            }
            
            rg.velocity = targetDirection.normalized * speed; //add the velocity to the player 
        }
    }

    //detecting if the player is on the ground if collided with objects that have the ground tag
    void OnCollisionEnter(Collision col){
        if (col.gameObject.tag == "ground") {
            grounded = true;
            jump = false;
        }
    }
}
