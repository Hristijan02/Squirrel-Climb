using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class TurnHandOff : MonoBehaviour
{
    public GameObject hand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.timerSecondsCount >= 2)
        {
            hand.gameObject.SetActive(false);
        } else 
            hand.gameObject.SetActive(true);
    }
}
