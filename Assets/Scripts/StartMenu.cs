using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.UI;
using System.IO;

public class StartMenu : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject settingsMenu;
    public GameObject volumeMenu;
    public GameObject continueMenu;
    public Slider volumeSlider;

    [System.Serializable]
    public class Settings{
        public float volume;
    }
    
    void Start()
    {

    }

    void Update()
    {
        
    }

    //load the game upon clicking the start button
    public void StartCheck()
    {
        if(GameManager.Instance.checkPoint){
            continueMenu.gameObject.SetActive(true);
            startMenu.gameObject.SetActive(false);
        }
        else{
            StartNew();
        }
    }

    public void ClearCheckPoint()
    {
        GameManager.Instance.checkPoint = false;
        StartNew();
    }

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

    public void ShowSettings()
    {
        startMenu.gameObject.SetActive(false);
        settingsMenu.gameObject.SetActive(true);
    }

    public void ShowVolume(){
        volumeSlider.value = GameManager.Instance.volume;
        settingsMenu.gameObject.SetActive(false);
        volumeMenu.gameObject.SetActive(true);
    }

    public void BackToMenu()
    {
        startMenu.gameObject.SetActive(true);
        settingsMenu.gameObject.SetActive(false);
    }

    public void BackToSettings()
    {
        settingsMenu.gameObject.SetActive(true);
        volumeMenu.gameObject.SetActive(false);
    }

    public void SetVolume()
    {
        GameManager.Instance.volume = volumeSlider.value;
        string path = Application.persistentDataPath + "/settings.json";

        Settings data = new Settings();
        data.volume = volumeSlider.value;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path,json);
    }
}
