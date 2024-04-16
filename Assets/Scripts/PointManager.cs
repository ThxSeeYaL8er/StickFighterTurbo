using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

/*
    The purpose of PointManager.cs is to manage the points on hit,
    winning, losing, and win screen for the game. In this script, 
    I control the pace of the game through starting/stopping the
    game scene whenever someone gets hit, and then tally the points
    correctly.
*/

public class PointManager : MonoBehaviour
{
    [SerializeField] AudioClip pointSound;
    [SerializeField] AudioSource auSource;
    public static int P1Points = 0;
    public static int P2Points = 0;
    //these 
    // Start is called before the first frame update
    void Start()
    {
        if (P1Points >= 3 || P2Points >= 3){ //resets points to 0 when someone wins
            P1Points = 0;
            P2Points = 0;
        }
        DontDestroyOnLoad(this.gameObject); //carries over points between resets
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async void ReloadScene(){
        if (P1Points >= 3){ //when player 1 wins, pause the game shortly before loading the win screen.
            Time.timeScale = 0f;
            await Task.Delay(TimeSpan.FromSeconds(1.5)); //stops time
            Time.timeScale = 1f; //waits one sec
            SceneManager.LoadScene(2); //loads new scene
        } 
        else if (P2Points >= 3){ //when player 2 wins, pause the game shortly before loading the win screen.
            Time.timeScale = 0f;
            await Task.Delay(TimeSpan.FromSeconds(1.5)); //stops time
            Time.timeScale = 1f; //waits one sec
            SceneManager.LoadScene(3); //loads new scene
        }
        else{
            Time.timeScale = 0f;
            await Task.Delay(TimeSpan.FromSeconds(1));
            Time.timeScale = 1f;
            SceneManager.LoadScene(1); //reloads the fight scene
        }
    }

    public void increasePoints(int playerNumber){ //when a player gets a hit, increase respective point
        auSource.clip = pointSound; //plays a sound of the point counter ticking up
        auSource.Play();
        if (playerNumber == 1){ //if youre player 1, player 1 gets a point
            P1Points += 1;
            ReloadScene();  //resets the fight
        } 
        else{ //if youre not player 1, player 2 gets a point
            P2Points += 1;
            ReloadScene(); //resets the fight
        }
    }
}
