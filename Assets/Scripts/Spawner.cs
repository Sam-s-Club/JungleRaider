using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // public GameObject[] enemies;
    public int difficulty;
    // private bool enemyAlive = false;
    // checking to see if this spawner will spawn an enemy and if so figure out which enemy will be spawned
    void Start()
    {
        //determine if an enemy should be spawned based on random number in range of difficulty
        //lower difficulty means higher number and greater range
        if(Random.Range(1,difficulty)==1){
            SpawnEnemy();
        }
    }

    void Update()
    {

    }

    void SpawnEnemy()
    {
        //determine enemy to be spawned by random number, will load the chosen enemy grabbing the prefab from the resources folder
            if(Random.Range(0,1)==0){
                // Instantiate(Resources.Load<GameObject>("Branch"),transform.position,transform.rotation);
            }
            else{
                // Instantiate(Resources.Load<GameObject>("Branch"),transform.position,transform.rotation);
            }
            // enemyAlive = true;
            // Instantiate(enemies[Random.Range(0,enemies.Length-1)],transform.position,transform.rotation);
    }

    
}
