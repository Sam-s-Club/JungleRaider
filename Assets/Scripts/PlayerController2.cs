using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    private Rigidbody rg;
    public float speed = 10.0F;
    public float jumpspeed = 10.0F;
    public float turnspeed = 10.0f;
    public float gravSpeed = 10.0F;
    public bool grounded = true;
    public bool jump = false;
    public float strafe;
    public float translation;
    Animator m_Animator;
    private GameObject playerSpawn;
   
    void Start () {
        rg = GetComponent <Rigidbody> ();
        m_Animator = gameObject.GetComponent<Animator>();
        playerSpawn = GameObject.Find("PlayerSpawn");
        transform.position = playerSpawn.transform.position;
    }
   
    void Update () {
        if (Input.GetKey (KeyCode.Space) ) {
            jump = true;
        }   
    }
    
    void FixedUpdate(){
        if(jump && grounded){
            grounded = false;
            m_Animator.SetTrigger("Jump");
            rg.velocity = new Vector3(rg.velocity.x, jumpspeed, rg.velocity.z);
        }
        else{
            Vector3 dir = Vector3.zero;
 
            dir.x = Input.GetAxis("Horizontal");
            dir.z = Input.GetAxis("Vertical");
            if(dir.x != 0 || dir.z != 0){
                m_Animator.SetBool("Run",true);
            }
            else{
                m_Animator.SetBool("Run",false);
            }
            Vector3 camDirection = Camera.main.transform.rotation * dir;
            Vector3 targetDirection = new Vector3(camDirection.x, 0, camDirection.z);
                
            if (dir != Vector3.zero) {
                transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(targetDirection),
                Time.deltaTime * turnspeed
                );
            }
            
            rg.velocity = targetDirection.normalized * speed; 
        }
    }

    void OnCollisionEnter(Collision col){
        if (col.gameObject.tag == "ground") {
            grounded = true;
            jump = false;
        }
    }
}
