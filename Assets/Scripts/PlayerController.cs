using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float horizontalInput;
    public float verticalInput;
    public bool jumpInput;
    public float speed = 10.0f;
    public float jumpSpeed = 10.0f;

    void Awake() {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        Debug.Log(Input.GetKeyDown(KeyCode.Space));
   
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
        if (Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }
    }
    void Jump() {
        rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
    }
    void FixedUpdate() {
        //rigidbody.velocity = new Vector3()
        //jumpInput = Input.GetKeyDown(KeyCode.Space);
    }
    
}
