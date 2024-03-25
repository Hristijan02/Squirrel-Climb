using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource audioSource;
    public AudioClip backgroundLoop;
    public AudioClip gameOverSound;

    public AudioClip burningFX;
    public AudioClip jumpFX;

    
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
       
        
    }
    
    // Start is called before the first frame update
   public void Start()
    {
        StartBackgroundSound();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartBackgroundSound()
    {
        audioSource.clip = backgroundLoop;
        audioSource.loop = true;
        audioSource.Play();
    }
   public void PlayBurningFX()
    {
        audioSource.PlayOneShot(burningFX);
    }
    
    public void PlayJumpFX()
    {
        audioSource.PlayOneShot(jumpFX);
    }
    
    public void PlayGameOverSound()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(gameOverSound);
    }
}
