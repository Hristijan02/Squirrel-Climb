using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DeathLine : MonoBehaviour
{
    public AudioClip clip;
    public AudioClip clipGameOver;
    AudioSource audioSource;
    public GameManager gameManager;
    public static bool GameOver;
    public static float timerStops;
    float startTime;
    public bool gameOverSound;
   

    private void Start()
    {
        GameOver= false;
        // startTime = Time.time;
        gameOverSound = false;
        audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Branches" || other.gameObject.tag == "Player" || other.transform.parent.gameObject.tag == "StartTrigger")
        {
            Destroy( other.gameObject );
            audioSource.PlayOneShot(clip, 1f);
        }

    }

    private void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Player").Length == 0) 
        {
            // Added isGameActive = false
            GameManager.Instance.isGameActive = false;
            GameOver = true;
            GameManager.Instance.panelGameOver.SetActive(true);
            //Time.timeScale = .2f;
            if (!gameOverSound)
            {
                audioSource.PlayOneShot(clip, .5f);
                audioSource.PlayOneShot(clipGameOver, .5f);
                //AudioManager.Instance.PlayGameOverSound();
                gameOverSound = true;
            }
        }
        
    }

    
}
