using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public GameObject gameMenu;
    public TextMeshProUGUI text;
    private GameObject spawnPoint;
    public GameObject resume;
    public GameObject settings;
   
    //Initialize the starting point for the player based off of whether or not a checkpoint has been set
    void Start() 
    {
        SetSpawnPoint();
    }
 
    //set the spawn point for the main character depending on whether or not the checkpoint has been reached
    void SetSpawnPoint() 
    {
        if(GameManager.Instance.checkPoint)
        {
            spawnPoint = GameObject.Find("Checkpoint");
        }
        else
        {
            spawnPoint = GameObject.Find("playerSpawn");
        }
        transform.position = spawnPoint.transform.position;
    }

    void Update()
    {
        if(transform.position.y < -15)//checking if the player has fallen off the world
        {
            GameOver();
        }
        else if(Input.GetKeyDown (KeyCode.P))//checking if the pause button was hit
        {
            Pause();
        }
    }

    //checking collision tags and setting game menu depending on the tag
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "enemy") 
        {
            GameOver();
        }
        else if(col.gameObject.tag == "Victory")
        {
            Victory();
        }
        else if(col.gameObject.tag == "checkpoint")
        {
            GameManager.Instance.checkPoint = true;
        }
    }

    //pause the game and show the menu after hitting the pause
    void Pause()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        text.text = "Paused";
        gameMenu.gameObject.SetActive(true);
        resume.SetActive(true);
    }

    //show the victory menu and pause all movement/sound
    void Victory()
    {
        Time.timeScale = 0;
        text.text = "Victory";
        gameMenu.gameObject.SetActive(true);
        resume.SetActive(false);
        settings.SetActive(false);
        GameManager.Instance.checkPoint = false;
    }

    //show the game over menu and pause all movement/sound
    void GameOver()
    {
        GameManager.Instance.gameOver = true;
        Time.timeScale = 0;
        text.text = "Game Over";
        gameMenu.gameObject.SetActive(true);
        resume.SetActive(false);
        settings.SetActive(false);
    }
}