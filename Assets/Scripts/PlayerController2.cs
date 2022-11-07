using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    private Rigidbody rg;
    // public GameObject GroundCheck;
    public float speed = 10.0F;
    public float jumpspeed = 10.0F;
    public float gravSpeed = 10.0F;
    public bool grounded = true;
    Animator m_Animator;
    private GameObject playerSpawn;
   
    void Start () {
        
        rg = GetComponent <Rigidbody> ();
        m_Animator = gameObject.GetComponent<Animator>();
        playerSpawn = GameObject.Find("PlayerSpawn");
        transform.position = playerSpawn.transform.position;
    }
   
    void Update () {
        float translation = Input.GetAxis ("Vertical") * speed;
        float strafe = Input.GetAxis ("Horizontal") * speed;

        m_Animator.SetFloat("Right",strafe);
        m_Animator.SetFloat("Forward",translation);

        translation *= Time.deltaTime;
        strafe *= Time.deltaTime;
       
        transform.Translate (strafe,0,translation);
        // grounded = Physics.CheckSphere(GroundCheck.transform.position, .2f, LayerMask.GetMask("Ground"));

        if (Input.GetKey (KeyCode.Space) && grounded) {
            grounded = false;
            Jump();
        }   
    }

    void Jump(){
        m_Animator.SetTrigger("Jump");
        rg.velocity = new Vector3(rg.velocity.x, jumpspeed, 0);
    }
    
    void FixedUpdate(){
        if (rg.velocity.y < .75f *jumpspeed || !(Input.GetKey (KeyCode.Space))){
            rg.velocity = Vector3.up * Physics.gravity.y * Time.fixedDeltaTime * gravSpeed;
        }
    }

    void OnCollisionEnter(Collision col){
        if (col.gameObject.tag == "ground") {
            grounded = true;
        }
    }
}
