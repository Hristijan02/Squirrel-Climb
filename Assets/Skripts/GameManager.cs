using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
   // public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
   
    public GameObject gameplay;
    public GameObject menu;
    public GameObject panelGameOver;
    public bool isGameActive;
    public float timerSecondsCount;
    public float gravityModifier = 1.7f;
  
    void Awake()
    {
        if(Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        panelGameOver.SetActive(false);
        
    }
 
   
  
    void Update()
    {  
        if (isGameActive)
        {
            timerSecondsCount += Time.deltaTime;
         
           TimeSpan timeSpan = TimeSpan.FromSeconds(timerSecondsCount); 
           string timeText = string.Format("{0:D2}:{1:D2}",  timeSpan.Minutes, timeSpan.Seconds);
           timerText.text = timeText;
           Debug.Log(timerSecondsCount);
          
        }
/*
        if (DeathLine.GameOver == true) {
            panelGameOver.SetActive(true);
        }*/
    }
    /*
    private void LateUpdate()
    {

        if (GameObject.FindGameObjectsWithTag("Player").Length == 0)
        {
            isGameActive = false;
            panelGameOver.SetActive(true);
            Time.timeScale = .2f;
           // StopTimer();
        }

    }*/

    public void ActiveGame()
    {
        //AudioManager.Instance.StartBackgroundSound();
        menu.gameObject.SetActive(false);
        gameplay.gameObject.SetActive(true);
        panelGameOver.SetActive(false);
        SceneManager.LoadScene("StartScene");
        Time.timeScale = 1;
        isGameActive = true;
        PlayerStats.jumpedTimes = 0;
     //  PlayerStats.casIgranja = 0;
        PlayerStats._score = 0;
        timerSecondsCount = 0;  
        
        
    }

    public void RestartGame()
    {
      
        gameplay.gameObject.SetActive(false);
        menu.gameObject.SetActive(true);
        //SceneManager.LoadScene("StartScene");
        SceneManager.LoadScene(0);
        gravityModifier = 1f;
        StartGame();
        panelGameOver.SetActive(false);
        
    }
    
    public void StartGame()
    {
        isGameActive = false;
        Time.timeScale = 1f;
        timerSecondsCount = 0;
        gravityModifier = 1f;
        panelGameOver.SetActive(false);
       // AudioManager.Instance.StartBackgroundSound();

    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
    
}
