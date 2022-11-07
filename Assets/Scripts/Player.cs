using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public GameObject gameMenu;

    void Start() {

    }

    void Update(){
        if(transform.position.y < 0){
            GameOver();
        }
    }

    void GameOver(){
        // Time.timeScale = 0;
        gameMenu.gameObject.SetActive(true);
    }
}