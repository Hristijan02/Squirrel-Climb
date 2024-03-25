using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpownPoint : MonoBehaviour
{
    
    [SerializeField] public GameObject[] branches;

  
  

    void Start()
    {
        InvokeRepeating("RandomSpown", 0f, 1.0f);
    }

    void RandomSpown() {
        float randomX = Random.Range(-2.0f, 2.0f);
        //float randomY = Random.Range(0, 10);
        int stevilo = Random.Range(0, branches.Length);
        
        if(randomX > 0) 
            Instantiate(branches[stevilo], new Vector3(randomX, 8, 0), Quaternion.identity);
        else 
            Instantiate(branches[stevilo], new Vector3(randomX, 8, 0), new Quaternion(branches[stevilo].transform.rotation.x, 180, branches[stevilo].transform.rotation.z,0));

    }
}
