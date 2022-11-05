using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    private Rigidbody rg;
    public GameObject GroundCheck;
    public float speed = 10.0F;
    public float jumpspeed = 10.0F;
    public float gravSpeed = 10.0F;
    bool grounded;
   
   
    void Start () {
        rg = GetComponent <Rigidbody> ();
    }
   
   
    void Update () {
        float translation = Input.GetAxis ("Vertical") * speed;
        float strafe = Input.GetAxis ("Horizontal") * speed;
        translation *= Time.deltaTime;
        strafe *= Time.deltaTime;
       
        transform.Translate (strafe, 0, translation);
        grounded = Physics.CheckSphere(GroundCheck.transform.position, .2f, LayerMask.GetMask("Ground"));
       
        if (Input.GetKey (KeyCode.Space) && grounded) {
            Jump();
        }
       
    }
    void Jump(){
        rg.velocity = new Vector3(rg.velocity.x, jumpspeed, 0);
    }
    
    void FixedUpdate(){
        if (rg.velocity.y < .75f *jumpspeed || !(Input.GetKey (KeyCode.Space))){
            rg.velocity = Vector3.up * Physics.gravity.y * Time.fixedDeltaTime * gravSpeed;
        }
    }
}
