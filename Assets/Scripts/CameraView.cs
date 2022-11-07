using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    public GameObject player;
    public float damping = 1;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;   
    }

    void LateUpdate() {
        Vector3 desiredPosition = player.transform.position + offset;
        Vector3 position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * damping);
        transform.position = desiredPosition;
        // if(Input.GetKey (KeyCode.Q)){
        //     transform.Translate(transform.right * 5);
        // }
        
        transform.LookAt(player.transform.position);
    }
}
