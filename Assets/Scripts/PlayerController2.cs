using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    private Rigidbody rg;
    private Animator animator;
    public GameObject GroundCheck;
    private Vector3 moveDirection;
    public AudioSource runSound;
    public AudioSource jumpSound;
    public float speed = 10.0F;
    public float jumpspeed = 10.0F;
    public float gravSpeed = 10.0F;
    bool grounded;
   
   
    void Start () {
        rg = GetComponent <Rigidbody> ();
        animator = GetComponent <Animator> ();
    }
   
   
    void Update () {
        float translation = Input.GetAxis ("Vertical") * speed;
        float strafe = Input.GetAxis ("Horizontal") * speed;
        translation *= (Time.deltaTime);
        strafe *= (Time.deltaTime);
        moveDirection = new Vector3(translation, 0, strafe);
        transform.Translate (strafe, 0, translation);
        grounded = Physics.CheckSphere(GroundCheck.transform.position, .2f, LayerMask.GetMask("Ground"));
       
        if (Input.GetKey (KeyCode.Space) && grounded) {
            Jump();
        }
        if (moveDirection == Vector3.zero) {
            animator.SetFloat("Speed", 0);
        }
        else {
            animator.SetFloat("Speed", 1);
            runSound.Play();
        }
       
    }
    void Jump(){
        rg.velocity = new Vector3(rg.velocity.x, jumpspeed, 0);
        jumpSound.Play();
    }
    
    void FixedUpdate(){
        if (rg.velocity.y < .5f *jumpspeed || !(Input.GetKey (KeyCode.Space))){
            rg.velocity =  Time.fixedDeltaTime * Physics.gravity.y * gravSpeed * Vector3.up *7;
            //Time.fixedDeltaTime Vector3.up *
        }
    }
}
