using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWinAnimation : MonoBehaviour
{

    [SerializeField] private Animator anim; 
    //animator
    
    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("isPunching", true);
        anim.SetBool("isPunching", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
