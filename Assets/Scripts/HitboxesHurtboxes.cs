using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxesHurtboxes : MonoBehaviour
{
    [SerializeField] AudioSource auSource;
    [SerializeField] AudioClip whiffSound;
    //sound manager
    [SerializeField] SpriteRenderer spriteR;
    private string currentSprite;
    //I use the sprite renderer to see what sprite is active, and can change colliders through that.
    [SerializeField] private GameObject playerParentMine;
    [SerializeField] private GameObject playerParentOther;
    private NewPlayerScript scriptMine;
    private NewPlayerScript scriptOther;
    //scripts
    [SerializeField] BoxCollider2D feetHurtbox;
    [SerializeField] BoxCollider2D bodyHurtbox;
    [SerializeField] BoxCollider2D sweepHurtbox;
    [SerializeField] BoxCollider2D jumpHurtbox;
    //variables for managing individual hurtbox colliders

    [SerializeField] BoxCollider2D sweepHitbox;
    [SerializeField] BoxCollider2D jumpHitbox;
    [SerializeField] BoxCollider2D punchHitbox;
    //variables for managing individual hitbox colliders

    public bool Player1;
    public bool Player2;

    // Start is called before the first frame update
    void Start()
    {
      scriptMine = playerParentMine.GetComponent<NewPlayerScript>();
      scriptOther = playerParentOther.GetComponent<NewPlayerScript>();
      //spriteR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        currentSprite = spriteR.sprite.name;
        manageHitboxes(currentSprite);
        manageHurtboxes(currentSprite);
    }

    private void OnTriggerEnter2D(Collider2D other) { //this method runs whenever another hitbox/hurtbox triggers it.
            if (checkLoss() && Player1 && ((other.gameObject.tag == "Hitbox2"))){
              if (other.transform.parent.gameObject.tag == "Player2"){
                //checks to see if the other player's HITBOX is touching your HURTBOX
                scriptMine.isHit = true; //if the other players HITBOX is touching your HURTBOX, give them a point.
              }
            }
            else if (checkLoss() && Player2 && ((other.gameObject.tag == "Hitbox1"))){
              if (other.transform.parent.gameObject.tag == "Player1"){ 
                //checks to see if the other player's HITBOX is touching your HURTBOX
                scriptMine.isHit = true; //if the other players HITBOX is touching your HURTBOX, give them a point.
              }
            }
        }
    private void manageHurtboxes(string sprite){ //manages /  changes what hurtboxes are active based on your current action.
        switch (currentSprite){
          case "j.K5": //jumping and kicking
            jumpHurtbox.enabled = true; //toggles on that specific collider.
            break;
          case "c.K4": //sweeping
          case "c.K5":
            sweepHurtbox.enabled = true; //toggles on that specific collider.
            break;
          case "b.P1":
          case "b.P2":
          case "b.P3":
          case "b.P4": //punching
            bodyHurtbox.enabled = false; //toggles off that specific collider.
            break;
          default:
            sweepHurtbox.enabled = false; //toggles off that specific collider.
            jumpHurtbox.enabled = false; //toggles off that specific collider.
            bodyHurtbox.enabled = true; //toggles on that specific collider.
            break;
        }
      
    }
    private void manageHitboxes(string sprite){ //manages / changes what hitboxes are active based on your current action.
      switch (currentSprite){
          case "j.K5": 
            if (!auSource.isPlaying){
              auSource.clip = whiffSound; //plays a sound whenever you throw out a move
              auSource.Play();
            }
            jumpHitbox.enabled = true; //toggles on that specific collider.
            break;
          case "c.K4":
            if (!auSource.isPlaying){
              auSource.clip = whiffSound; //plays a sound whenever you throw out a move
              auSource.Play();
            }
            sweepHitbox.enabled = true; //toggles on that specific collider.
            break;
          case "b.P4":
            if (!auSource.isPlaying){
              auSource.clip = whiffSound; //plays a sound whenever you throw out a move
              auSource.Play();
            }
            punchHitbox.enabled = true; //toggles on that specific collider.
            break;
          default:
            sweepHitbox.enabled = false; //toggles off that specific collider.
            jumpHitbox.enabled = false; //toggles off that specific collider.
            punchHitbox.enabled = false; //toggles off that specific collider.
            break;
        }
    }

    private bool checkLoss (){ //checks to see if youre using the losing move, as to not give any false points.
      if (scriptMine.isPunching && scriptOther.isJumping){
        return false; //you win
      }
      else if (scriptMine.isJumping && scriptOther.isSweeping){
        return false; //you win
      }
      else if (scriptMine.isSweeping && scriptOther.isPunching){
        return false; //you win
      }
      else{
        return true; //you lose
      }
    }
}
