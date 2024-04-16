using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioSource auSource;
    //Sound manager
    [SerializeField] RectTransform rectTransform;
    //Used to make the button bigger when hovered over
    public bool isClickable = true;
    //allows me to toggle whether or not the user can activate buttons
    //[SerializeField] GameObject gameMNGR;
    //private PointManager pointMNGR;
    //grabs the script for the Point manager so I can reset the points

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = transform.GetComponent<RectTransform>();
        //pointMNGR = gameMNGR.GetComponent<PointManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick(){
        if (isClickable){
            auSource.Play();
            SceneManager.LoadScene(0);
        }
    }

     public void OnEnter(){
        if (isClickable){
        rectTransform.sizeDelta = new Vector2 (140, 40);
        }
    }

    public void OnExit(){
        if (isClickable){
        rectTransform.sizeDelta = new Vector2 (130, 30);
        }
    }
}
