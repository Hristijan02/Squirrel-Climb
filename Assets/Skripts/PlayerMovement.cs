using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
     private Vector2 startTouchPosition;
     private Vector2 endTouchPosition;
    private Touch touch;
    public Animator animator;
    public Rigidbody player;
    public float moveSpeed;

    //  public float rayDetector = 0.1f;


    public AudioClip clip;
    AudioSource audioSource;

    [SerializeField] float jumpForce;
     private bool isJumping;
     public bool isMove;
    private void Start()
    {
       isJumping = false;
       Physics.gravity *= GameManager.Instance.gravityModifier;
       player = GetComponent<Rigidbody>();

        audioSource = GetComponent<AudioSource>();
    }

    /*
    private void Update()
    {
        if (Input.touchCount > 0)
        {

            touch = Input.GetTouch(0); 
             
            {
             if (touch.phase == TouchPhase.Moved) 
                {
                    transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * moveSpeed, transform.position.y, transform.position.z);

                }

              
            }
        }


    }*/

    
    void Update()
    {
        /*if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;

            if (endTouchPosition.x > startTouchPosition.x)
            {
                Right();
            }

            if (endTouchPosition.x < startTouchPosition.x)
            {
                Left();
            }
        }*/

        if (player.transform.position.y >= 6) {
            
            player.transform.position = new Vector3(player.transform.position.x, 6, player.transform.position.z);       
        }

        if (player.transform.position.x >= 2.4f)
        {

            player.transform.position = new Vector3(2.4f, player.transform.position.y, player.transform.position.z);
        }

        if (player.transform.position.x <= -2.4f)
        {

            player.transform.position = new Vector3(-2.4f, player.transform.position.y, player.transform.position.z);
        }

        if (Input.GetMouseButtonDown(0))
        {
            isMove = true;
        }

        if (Input.GetMouseButtonUp(0))
            isMove = false;

        if (isMove)
        {
            float temp = Mathf.Abs((player.transform.position - Camera.main.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                temp));

            float oldX = player.transform.position.x;
            float newX = worldPosition.x;
            float maxSpeed = 0.15f;
            // make sure the player is not moving too fast
            if (Mathf.Abs(newX - oldX) > maxSpeed)
            {
                newX = oldX + Mathf.Sign(newX - oldX) * maxSpeed;
            }

            player.transform.position = new Vector3(newX, player.transform.position.y,
                player.transform.position.z);
            
            // make sure to turn the player around
            if (newX > oldX)
            {
                player.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (newX < oldX)
            {
                player.transform.rotation = Quaternion.Euler(0, 180, 0);
            }

          
            
        }
        /*
        if (isJumping)
        {
            Vector3 rayStart = transform.position + Vector3.up * 0.5f;
            RaycastHit hit;

            if (Physics.Raycast(rayStart, Vector3.down, out hit, rayDetector))
            {
                if (hit.collider.CompareTag("Branches"))
                {
                    player.AddForce(transform.up * jumpForce);
                    Invoke("StopJumping", 0.3f);
                }
            }
        */



    }
    
    private void Right()
    {
        player.transform.position = new Vector3(player.transform.position.x + 1 , player.transform.position.y, player.transform.position.z);
        if (player.transform.rotation.y == 0)
        {
            return;
        }
        else 
        {
            player.transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
        }
        

    }

    private void Left()
    {
        player.transform.position = new Vector3(player.transform.position.x -1 , player.transform.position.y, player.transform.position.z);
        if (player.transform.rotation.y == 180) 
        {
            return;
        }
        else
        {           
            player.transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
        }

    }
    
    // Movement 
   


    void OnCollisionEnter(Collision other)
    {
       
        if (other.gameObject.tag == "Branches") {
            isJumping = false;
            player.AddForce(transform.up * jumpForce, ForceMode.Impulse); //ForceMode.Impulse
            player.velocity = new Vector3(player.velocity.x,0f, player.velocity.z);

            PlayerStats.jumpedTimes++;
        }
        else
        {
            isJumping = true;
           
        }
        if(!isJumping)
        {
            animator.SetTrigger("Jump");
            audioSource.PlayOneShot(clip, .5f);
           // Debug.Log("Played sound " + clip.name);
          //  Debug.Log("jumped");
        }

     }
    /*
    private void StopJumping()
    {
        isJumping = false;
        
    }*/
    



}
