using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //reload the game upon being called, this is only deployed while in game
    public void Reload()
    {  
        Debug.Log("Reloading");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //exit back to the main menu upon this being called
    public void ExitToMenu()
    {  
        Debug.Log("Exiting");
        SceneManager.LoadScene(0);
    }
}
