using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int difficulty;
    // checking to see if this spawner will spawn an enemy and if so figure out which enemy will be spawned
    void Start()
    {
        //determine if an enemy should be spawned based on random number in range of difficulty
        //lower difficulty means higher number and greater range
        if(Random.Range(1,3)==1){
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        Debug.Log(transform.position);
        //determine enemy to be spawned by random number, will load the chosen enemy grabbing the prefab from the resources folder
            if(Random.Range(0,2)==0){
                Instantiate(Resources.Load<GameObject>("Spider"),transform.position,Quaternion.Euler(180,0,0));
            }
            else{
                Instantiate(Resources.Load<GameObject>("Snakes"),transform.position,transform.rotation);
            }
    }
}
