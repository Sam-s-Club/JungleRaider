using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reload()
    {
        // Time.timeScale = 1;   
        Debug.Log("Reloading");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
             
    }

    public void ExitToMenu()
    {
        // Time.timeScale = 1;   
        Debug.Log("Exiting");
        SceneManager.LoadScene(0);
    }
}
