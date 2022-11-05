using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public float horizontalInput;
    //public float verticalInput;
    public float speed = 10.0f;
    int horizMoveDir;
    int vertMoveDir;
    Rigidbody rigidBody;

    void Awake() {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update(){
        horizMoveDir = (int)Input.GetAxisRaw("Horizontal");
        //Debug.Log(horizMoveDir);
        vertMoveDir = (int)Input.GetAxisRaw("Vertical");
        //Debug.Log(vertMoveDir);
    }
    void FixedUpdate() {
        
        rigidBody.velocity = new Vector3(horizMoveDir, rigidBody.velocity.z, 0);
        
        //rigidBody.velocity = new Vector3(vertMoveDir, rigidBody.velocity.z, 0);
    }
}