using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    [SerializeField] AudioSource auSource;
    //Sound manager
    [SerializeField] RectTransform rectTransform;
    //Used to make the button bigger when hovered over
    public bool isClickable = true;
    //allows me to toggle whether or not the user can activate buttons

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = transform.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick(){
        if (isClickable){
            auSource.Play(); //plays a sound effect
            SceneManager.LoadScene(1); //starts the game
        }
    }

     public void OnEnter(){
        if (isClickable){
        rectTransform.sizeDelta = new Vector2 (140, 40);
        //makes the button appear larger when hovered
        }
    }

    public void OnExit(){
        if (isClickable){
        rectTransform.sizeDelta = new Vector2 (130, 30);
        //sizes the button back down
        }
    }
}
