using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    // Start is called before the first frame update
    public float spiderSPD = 5;  
    public float turnSPD = 180; 
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
        //moves spider 
        transform.position += transform.forward *spiderSPD * Time.deltaTime  * -1
        ;
         
        //turns spider  
        float turnDirection = Input.GetAxis( "Horizontal "); 
        transform.Rotate(Vector3.up * turnDirection * turnSPD *  Time.deltaTime * -1);
 
        
    }
}
