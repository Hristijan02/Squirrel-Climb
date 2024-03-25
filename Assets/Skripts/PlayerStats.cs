using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
   

    public static int jumpedTimes;
    public TMP_Text jumpsMade;

    public TMP_Text scoreText;
    public static int _score;
   /*
    public TMP_Text timePlayed;
    public static float casIgranja;
    float timeSurvived;
   */

    /*
    public static PlayerStats instance;


    
    void Awake()
    {  
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }*/

   

    void Update() 
    {
     //   casIgranja += Time.deltaTime;
    //    casIgranja = Mathf.Clamp(casIgranja, 0f, Mathf.Infinity);

        jumpsMade.text = jumpedTimes.ToString() + " Jumps";
       
        scoreText.text = _score.ToString() + "";

       // timeSurvived = casIgranja;


      /*  if (!GameManager.Instance.isGameActive)
        {
          //  timePlayed.text = timeSurvived.ToString();
          //  timePlayed.text = string.Format("{0:00.00}", timeSurvived);
            timePlayed.text = casIgranja.ToString();
            timePlayed.text = string.Format("{0:00.00}", casIgranja);
        }
        else 
        {
            Debug.Log("Add another timer for end game!");
        }

      
        */
        
    }

  
}
