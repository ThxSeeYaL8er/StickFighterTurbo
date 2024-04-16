using System.Security.AccessControl;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

/*
    This script, NewPlayerScript.cs, is easily the most
    important script in the project.
*/
    public class NewPlayerScript : MonoBehaviour{

        [SerializeField] AudioSource auSource;
        [SerializeField] AudioClip jumpSound;
        [SerializeField] AudioClip dodgeSound;
        //Audio sources and sounds
        [SerializeField] GameObject Pointer;
        private PointManager points;
        //this GameObject and Script lets me manage the points and scene through the player detection.
        private Rigidbody2D rb;
        //rigidbody
        [SerializeField] private Animator anim; 
        //animator
        private Vector2 movement;
        //vector made for calculating velocity in any given direction.
        [SerializeField] float speed = 5f;  
        //float speed changes  the speed of everything. Walking, jumping, gravity, etc.
        public float Yv = 0f;
        //vertical velocity
        private float XvMultiplier = 1f;
        //horizontal momentum
        private float movementX;
        //used in the vector and OnMove method to take horizontal input.
        private float movementY;
        //used in the vector and OnMove method to take horizontal input.
        private float framesCN = 0;
        //counts time
        private float time_start;
        //temporary variable for move durations
        private float time_now;
        //temporary variable for move durations
        [SerializeField] float jumpSpeed = 2.2f;
        //calculates how  fast you rise when jumping
        [SerializeField] float fallSpeed = 0.1f;
        //calculates how fast you fall when falling 

        private bool touchingGround = false;
        //checks if the player is grounded
        public bool isJumping = false;
        public bool isSweeping = false;
        public bool isPunching = false;
        public bool isWalking = false;
        //These four booleans check the player's move state
        
        public bool isActionable = true;
        //checks if the player is doing something

        public bool isHit = false;
        //checks if the player is hit

        [SerializeField] private bool isPlayer1 = false;
        [SerializeField] private bool isPlayer2 = false;
        

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            points = Pointer.GetComponent<PointManager>();
        }


        // Update is called once per frame
        void FixedUpdate()
        {
            //'Vector2 movement' and 'rb.velocity' arre what allows my physics engine
            //to eafect the player. effectively granting movement
            Vector2 movement = new Vector2(movementX * XvMultiplier, Yv);
            rb.velocity = (movement * speed);
            rb.velocity = rb.velocity * 0.9f;
            
            //checks if youre touching the ground
            if (touchingGround){
                Yv = 0;
            }
            else {
                Yv -= fallSpeed;
            }
            
        }
        //Update() runs  constantly during gameplay. allowing for loops 
        //such as running animations and counting reeal-life time.
        private void Update() 
        {
            if (isPlayer1){
                anim.SetFloat("speed", movementX); 
            }
            else if (isPlayer2){
                anim.SetFloat("speed", -1 * movementX); 
            }
            
            anim.SetBool("isJumping", isJumping);
            anim.SetBool("isSweeping", isSweeping);
            anim.SetBool("isPunching", isPunching);
            anim.SetBool("isHit", isHit);
            
            isWalking = (movementX != 0);
            framesCN += Time.deltaTime;

            if (isHit && isPlayer1){
                points.increasePoints(2); //gives player 2 a point
                isHit = false;
            }
            else if (isHit && isPlayer2){
                points.increasePoints(1); //gives player 1 a point
                isHit = false;
            }
        }
        //Every time you touch something, this method checks to see 
        //what that thing is, and therefore  what to do upon touchign it.
        void OnCollisionEnter2D(Collision2D collision2D) {
            if (collision2D.gameObject.tag == "Ground"){
                XvMultiplier = 1f; //allows the player to walk again
                touchingGround = true;
            }
            
        }
        //similarly to the last method, this method checks for collisions.
        //however, this method instead checks when you STOP touching something
        private void OnCollisionExit2D(Collision2D other) {
            
        }
        
        public void Move(InputValue movementValue)
        {
                //move is a method that's permantently active as long 
                //as the left or right keys are being held down
            if (isActionable){
                Vector2 movementVector = movementValue.Get<Vector2>(); 
                //affects the vector, moving the player's positon on screen
                movementX = movementVector.x;
                movementY = movementVector.y;
                 //variables used to calculate movement/position
            }
            
        }    

        public void Jump(InputValue Value)
        {
            //these methods get called when the input system 
            //sends an input to the player.
            if (touchingGround && isActionable){
                auSource.clip = jumpSound; //Sets the sound to play
                auSource.Play(); //plays the sound
                isJumping = true; //changes the state
                movementX = 0f; //disables horizontal movement
                Yv = jumpSpeed; //sets your vertical velocity upward
                touchingGround = false; //clarifies you are not grounded
                isActionable = false; //prevents the player from doing anything else
                StartCoroutine(InactionableTime(0.85f, false)); //waits
                
            }
        }

        public void Sweep(InputValue Value)
        {
            //these methods get called when the input system 
            //sends an input to the player.
            if (touchingGround && isActionable){
                isSweeping = true; //changes the state
                movementX = 0f; //disables horizontal movement
                isActionable = false; //prevents the player from doing anything else
                StartCoroutine(InactionableTime(0.85f, false)); //waits
                
            }
        }
        
        public void Punch(InputValue Value)
        {
             //these methods get called when the input system 
            //sends an input to the player.
            if (touchingGround && isActionable){
                auSource.clip = dodgeSound; //Sets the sound to play
                auSource.Play(); //plays the sound
                isPunching = true; //changes the state
                movementX = 0f; //disables horizontal movement
                isActionable = false; //prevents the player from doing anything else
                StartCoroutine(InactionableTime(0.85f, false)); //waits
                
            }
        }


        IEnumerator InactionableTime (float timeInSeconds, bool inactionable){ 
            time_start = framesCN;
            time_now = 0;
            isActionable = inactionable;
            while (true){
                //waits for time_now to go above the inserted wait before doing an action

                yield return new WaitForSeconds(timeInSeconds);

                isActionable = true;
                isJumping = false;
                isSweeping = false;
                isPunching = false;
                //Rearranges booleans to allow player m,ovement and animation
                break;
            }
           
            //resets the player's ability to move after they complete the move.
        }

    }


