using System.Security.AccessControl;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputManager : MonoBehaviour
{
    [SerializeField] GameObject Player1;
    [SerializeField] GameObject Player2;

    private NewPlayerScript P1Script;
    private NewPlayerScript P2Script;
    //gets the game object of both players and their scripts

    // Start is called before the first frame update
    void Start()
    {
        P1Script = Player1.GetComponent<NewPlayerScript>();
        P2Script = Player2.GetComponent<NewPlayerScript>();
        //initializes the players in the script, allowing me to edit
        //-freely from there
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMove1(InputValue movementValue)
    {
        P1Script.Move(movementValue);
    }  

    public void OnJump1(InputValue movementValue)
    {
        P1Script.Jump(movementValue);
    }   

    public void OnSweep1(InputValue movementValue)
    {
        P1Script.Sweep(movementValue);
    } 

    public void OnUppercut1(InputValue movementValue)
    {
        P1Script.Punch(movementValue);
    } 

    public void OnMove2(InputValue movementValue)
    {
        P2Script.Move(movementValue);
            
    }     

    public void OnJump2(InputValue movementValue)
    {
        P2Script.Jump(movementValue);
    } 

    public void OnSweep2(InputValue movementValue)
    {
        P2Script.Sweep(movementValue);
    } 

    public void OnUppercut2(InputValue movementValue)
    {
        P2Script.Punch(movementValue);
    } 
}
