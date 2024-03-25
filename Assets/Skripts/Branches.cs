using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branches : MonoBehaviour
{


    [SerializeField] public int hitsToDestroy = 1;

    [SerializeField] public int scorePoints = 50;
    [SerializeField] ParticleSystem leafsFall;

    [SerializeField] float speed = 25f;


    private void Start()
    {
        Invoke("SelfDestroy", 7.0f);
    }

    private void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }


    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            hitsToDestroy--;
            leafsFall.Play();
            PlayerStats._score += scorePoints;
            if (hitsToDestroy <= 0)
            {
                Destroy(gameObject);
            }

        }
         
    }


    void SelfDestroy() 
    {
        Destroy(gameObject);
    }
   


}
