using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetector : MonoBehaviour
{
    [SerializeField] BoxCollider _childboxCollider;   //sproži
 //    [SerializeField] BoxCollider _parentboxCollider;  //zazna


    private void Awake()
    {
       // _childboxCollider = GetComponent<BoxCollider>();
      //  _childboxCollider.enabled = false;
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            _childboxCollider.enabled = true;   
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            _childboxCollider.enabled = false;
          
        }
    }
}
