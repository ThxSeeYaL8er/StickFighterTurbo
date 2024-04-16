using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointToken : MonoBehaviour
{
    public int pointNumber;
    public int player; 
    private Image sprite;
    //gets the image of the win tokens
    [SerializeField] GameObject gameMNGR;
    private PointManager pointMNGR;
    //grabs the script for the Point manager so I can tally up the points

    private int P1pts = 0;
    private int P2pts = 0;
    //points

    // Start is called before the first frame update
    void Start()
    {
        pointMNGR = gameMNGR.GetComponent<PointManager>();
        sprite = GetComponent<Image>();

        P1pts = PointManager.P1Points;
        P2pts = PointManager.P2Points;

        if (P1pts >= 3 || P2pts >= 3){
            P1pts = 0;
            P2pts = 0;
        }

        loadPoints();
        //initiates the image as a variable I can change
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //changes the color based on what point  token you are
    public void loadPoints (){
        if (player == 1 && pointNumber == 1 && P1pts >= 1){
            sprite.color = new Color32(255, 60, 60, 255); 
        }
        else if (player == 1 && pointNumber == 2 && P1pts >= 2){
            sprite.color = new Color32(255, 60, 60, 255);
        }
        else if (player == 1 && pointNumber == 3 && P1pts >= 3){
            sprite.color = new Color32(255, 60, 60, 255);
        }
        else if (player == 2 && pointNumber == 1 && P2pts >= 1){
            sprite.color = new Color32(0, 140, 255, 255);
        }
        else if (player == 2 && pointNumber == 2 && P2pts >= 2){
            sprite.color = new Color32(0, 140, 255, 255);
        }
        else if (player == 2 && pointNumber == 3 && P2pts >= 3){
            sprite.color = new Color32(0, 140, 255, 255);
        }
        else{
            sprite.color = new Color32(255, 255, 255, 255);
        }
    }
}
