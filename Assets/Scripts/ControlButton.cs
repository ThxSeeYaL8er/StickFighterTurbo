using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlButton : MonoBehaviour
{
    [SerializeField] AudioSource auSource;
    //Sound manager
    [SerializeField] private GameObject playButton;
    private PlayButton scriptPlay;
    //scripts
    [SerializeField] RectTransform rectTransform;
    //Used to make the button bigger when hovered over
    [SerializeField] private GameObject UIBox;
    public bool isClickable = true;
    //allows me to toggle whether or not the user can activate buttons

    // Start is called before the first frame update
    void Start()
    {
        scriptPlay = playButton.GetComponent<PlayButton>();
        //grabs the buttons so I can toggle them on and off!

        rectTransform = transform.GetComponent<RectTransform>();
        //grabs the image for the button so I can make it larger
        //UIBox = transform.GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick(){
        if (isClickable){
            auSource.Play(); //plays a sound
            rectTransform.sizeDelta = new Vector2 (130, 30);
            //resets the button/s size
            UIBox.SetActive(true); //opens the control box
            isClickable = false; //toggles this button off
            scriptPlay.isClickable = false; //toggles the other buttons off
        }
    }

     public void OnEnter(){
        if (isClickable){
        rectTransform.sizeDelta = new Vector2 (140, 40); // makes button big
        }
    }

    public void OnExit(){
        if (isClickable){
        rectTransform.sizeDelta = new Vector2 (130, 30); // makes button small
        }
    }
}
