using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool checkPoint = false;
    public float volume = 1.0f;
    public Slider volumeSlider;
    public bool gameOver = false;

    [System.Serializable]
    public class Settings{
        public float volume;
    }
    
    //awake instance of gamemanager for the new game
    private void Awake() 
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadSettings();//load saved settings
    }

    //load the settings from persistent data
    private void LoadSettings()
    {
        string path = Application.persistentDataPath + "/settings.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Settings data = JsonUtility.FromJson<Settings>(json);

            volume = data.volume;
            volumeSlider.value = data.volume;
        }
    }
}
