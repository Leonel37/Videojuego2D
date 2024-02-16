using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementJugador2 : MonoBehaviour
{


    public float movementSpeed = 3.0f;
    Vector2 movement = new Vector2();
    Rigidbody2D rb2D;
    Animator animator;
    string animationState = "AnimationState";

    enum CharStates
    {
        pomodoroSur = 1,
        pomodoroEste = 2,
        pomodoroOeste = 3,
        pomodorNorte = 4
    }

    // Start is called before the first frame update
    void Start()
    {
          rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
           
    }

    // Update is called once per frame
    void Update()
    {
          this.UpdateState();
    }


     private void UpdateState(){
        if (movement.x > 0){
            animator.SetInteger(animationState, (int)CharStates.pomodoroEste);
        }else if (movement.x < 0){
            animator.SetInteger(animationState, (int)CharStates.pomodoroOeste);
        }else if (movement.y > 0){
             animator.SetInteger(animationState, (int)CharStates.pomodorNorte);
        }else if (movement.y < 0){
            animator.SetInteger(animationState, (int)CharStates.pomodoroSur);
        }else{
            animator.SetInteger(animationState, (int)CharStates.pomodoroSur);
        }

    }

     private void FixedUpdate()
    {
        MoveCharacter();
    }


    private void MoveCharacter() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize();
        rb2D.velocity= movement * movementSpeed;
    } 
}
