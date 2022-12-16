using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public AudioSource mainMusic;
    public AudioSource enemyMusic;
    public AudioSource jumpSound;
    public AudioSource runSound;
    public AudioSource firstCombatSound;
    public AudioSource secondCombatSound;
    public AudioSource thirdCombatSound;
    private float volume;

    // Initialize all values needed and start the music
    void Start()
    {
        GameManager.Instance.gameOver = false;
        Time.timeScale = 1;
        volume = GameManager.Instance.volume;
        mainMusic.volume = volume;
        jumpSound.volume = volume;
        runSound.volume = volume;
        firstCombatSound.volume = volume;
        secondCombatSound.volume = volume;
        thirdCombatSound.volume = volume;
        mainMusic.loop = true;
        mainMusic.Play(); 
    }

    //check if game over and stop music
    void Update()
    {
        if(GameManager.Instance.gameOver)
        {
            mainMusic.Stop();
            jumpSound.Stop();
            runSound.Stop();
            firstCombatSound.Stop();
            secondCombatSound.Stop();
            thirdCombatSound.Stop();
        }
        else if(GameManager.Instance.volumeChanged)
        {
            GameManager.Instance.volumeChanged = false;
            SetVolume(GameManager.Instance.volume);
        }
    }
    
    //set the volume of all audio sources
    public void SetVolume(float volumeToChange)
    {
        volume = volumeToChange;
        mainMusic.volume = volumeToChange;
        jumpSound.volume = volumeToChange;
        runSound.volume = volumeToChange;
        firstCombatSound.volume = volumeToChange;
        secondCombatSound.volume = volumeToChange;
        thirdCombatSound.volume = volumeToChange;
    }

}
