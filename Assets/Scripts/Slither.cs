using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slither : MonoBehaviour
{
    // Start is called before the first frame update
    public float snakeSPD = 5; 
    public float turnSPD = 5;
    public float tailSPD = 50;
    public int tailSpacing = 5;
    public GameObject tailPrefab;
    private List<GameObject> tailTotal = new List<GameObject>();
    private List<Vector3> followHead = new List<Vector3>();

    void Start()
    {
        //how long tail is 
        GrowSnake();
        GrowSnake();
        GrowSnake();
        GrowSnake();
        GrowSnake();
        GrowSnake();
        GrowSnake();
        GrowSnake();

    }

    // Update is called once per frame
    void Update()
    { 
        //moves snake
        transform.position += transform.forward *snakeSPD *  Time.deltaTime; 
        
        //turns snake
         transform.Rotate(Vector3.up  * turnSPD * Time.deltaTime);
      
        //Marks location of Head
        followHead.Insert(0, transform.position); 

        //Allows tail to follow head
        int index = 0; 
        foreach (var body in tailTotal)  {
            Vector3 point = followHead[Mathf.Min(index * tailSpacing, followHead.Count - 1) ];
            Vector3 moveDirection = point - body.transform.position; 
            body.transform.position +=  moveDirection * tailSPD * Time.deltaTime;
            body.transform.position =  point; 
            index++;  
        }
        }

            // function for adding tails/ bodies to snake head
          private void GrowSnake() {  
            GameObject body = Instantiate(tailPrefab); 
            tailTotal.Add( body);  
        
    }
}