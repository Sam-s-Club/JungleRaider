using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class StartMenu : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //load the game upon clicking the start button
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    //exit the game, checks if in the editor or in the executable
    public void Exit()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
