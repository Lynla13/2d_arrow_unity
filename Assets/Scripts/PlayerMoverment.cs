using System.Timers;
using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoverment : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D theRB;

    public Transform groundCheckPoint, groundCheckPoint2;
    public LayerMask whatIsGround;
    private bool isGrounded; 

    public Transform playerSR; 

    public float hangTime; 
    private float hangCounter;

    public float jumpBufferLength =.1f; 
    private float jumpBufferCount;

    public Transform camTarget;
    public float aheadAmount, aheadSpeed;    


    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent <Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        //Move horizontally 
        theRB.velocity = new Vector2 (Input.GetAxisRaw ("Horizontal")*moveSpeed, theRB.velocity.y);

        //Check if player on the ground
        isGrounded = Physics2D.OverlapCircle (groundCheckPoint.position,.1f, whatIsGround) || Physics2D.OverlapCircle (groundCheckPoint2.position,.1f, whatIsGround);

        // manage hang time
        if (isGrounded) 
        {
            hangCounter = hangTime; 

        }  else 
        {
            hangCounter -= Time.deltaTime; 
        }

        //manage Jump Buffer 
        if (Input.GetButtonDown("Jump")) 
        {
            jumpBufferCount = jumpBufferLength;
        }else 
        {
            jumpBufferCount -= Time.deltaTime;
        }

        //Jump in the air 
        if (hangCounter > 0f && jumpBufferCount >= 0) 
        {
            theRB.velocity = new Vector2 (theRB.velocity.x, jumpForce);
            jumpBufferCount = 0;
        }

        //Small Jump (Know exact height and jump time)
        if (Input.GetButtonDown ("Jump") && theRB.velocity.y > 0) 
        {
            theRB.velocity = new Vector2 (theRB.velocity.x , theRB.velocity.y *.5f);
        }

        //Flip the player
        if (Input.GetAxisRaw ("Horizontal") > 0) 
        {
            playerSR.localScale = new Vector3 (1, 1,1);
            Debug.Log (Input.GetAxisRaw ("Horizontal"));

        } else if (Input.GetAxisRaw ("Horizontal") < 0) 
        {
            playerSR.localScale = new Vector3 (-1, 1,1);
            Debug.Log (Input.GetAxisRaw ("Horizontal"));
        }

    }

    public void goLeft() {

    }
    public void goRight() {

    }

     public void jump() {

    }



}
