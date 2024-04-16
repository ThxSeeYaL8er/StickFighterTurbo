using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    [SerializeField] AudioSource auSource;
    //Sound manager
    [SerializeField] private GameObject playButton;
    private PlayButton scriptPlay;
    [SerializeField] private GameObject contButton;
    private ControlButton scriptCont;

    //grabs the play and controll buttons so I can toggle them back on

    [SerializeField] RectTransform rectTransform;
    //Used to make the button bigger when hovered over
    [SerializeField] private GameObject UIBox;
    public bool isClickable = true;
    //allows me to toggle whether or not the user can activate buttons

    // Start is called before the first frame update
    void Start()
    {
        scriptPlay = playButton.GetComponent<PlayButton>();
        scriptCont = contButton.GetComponent<ControlButton>();
        //grabs the button objects so I can toggle them on and off!
        rectTransform = transform.GetComponent<RectTransform>();
        //UIBox = transform.GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick(){
        if (isClickable){
            auSource.Play();
            UIBox.SetActive(false);
            scriptPlay.isClickable = true;
            scriptCont.isClickable = true;
        }
    }

     public void OnEnter(){
        if (isClickable){
        rectTransform.sizeDelta = new Vector2 (50, 50);
        }
    }

    public void OnExit(){
        if (isClickable){
        rectTransform.sizeDelta = new Vector2 (40, 40);
        }
    }
}
