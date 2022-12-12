using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public GameObject gameMenu;
    public TextMeshProUGUI text;

    void Start() {
        
    }

    //checking if the player has fallen off the world
    void Update(){
        if(transform.position.y < 0){
            GameOver();
        }
    }

    //checking collision tags and setting game menu depending on the tag
    void OnCollisionEnter(Collision col){
        if (col.gameObject.tag == "enemy") {
            GameOver();
        }
        else if(col.gameObject.tag == "victory"){
            Victory();
        }
    }

    void Victory(){
        text.text = "Victory";
        gameMenu.gameObject.SetActive(true);
    }

    void GameOver(){
        text.text = "Game Over";
        gameMenu.gameObject.SetActive(true);

    }
}