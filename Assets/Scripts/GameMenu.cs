using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class GameMenu : MonoBehaviour
{
    public GameObject gameMenu;
    public GameObject settingsMenu;
    public GameObject volumeMenu;
    
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

    //resume function to set the time again and hide game menu
    public void Resume()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        gameMenu.gameObject.SetActive(false);
    }

    //show the settings menu and hide the game menu
    public void ShowSettings()
    {
        gameMenu.gameObject.SetActive(false);
        settingsMenu.gameObject.SetActive(true);
    }

    //show the volume menu, set slider to current value and hide settings menu
    public void ShowVolume()
    {
        volumeSlider.value = GameManager.Instance.volume;
        settingsMenu.gameObject.SetActive(false);
        volumeMenu.gameObject.SetActive(true);
    }

    //back button functionality, show game menu and hide settings menu
    public void BackToMenu()
    {
        gameMenu.gameObject.SetActive(true);
        settingsMenu.gameObject.SetActive(false);
    }

    //back button functionality, show settings menu and hide volume menu
    public void BackToSettings()
    {
        settingsMenu.gameObject.SetActive(true);
        volumeMenu.gameObject.SetActive(false);
    }

    //set the volume when the slider is changed by the user, save it to persistent data
    public void SetVolume()
    {
        GameManager.Instance.volume = volumeSlider.value;
        
        string path = Application.persistentDataPath + "/settings.json";
        Settings data = new Settings();
        data.volume = volumeSlider.value;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path,json);
    }

    //reload the game upon being called, this is only deployed while in game
    public void Reload()
    {  
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //exit back to the main menu upon this being called
    public void ExitToMenu()
    {  
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}