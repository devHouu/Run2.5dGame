using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PFG.core;


public  enum animationState{
   
   movement,
   jump,
   roll,
   land


}

public class animeController : MonoBehaviour
{
   inputHandler input_x;
   public  GameObject a_nim;
   public  Animator Anim;
   public animationState currentStates;  
    // Start is called before the first frame update
    void Start()
    {     
        Anim = a_nim.GetComponent<Animator>();
        input_x = GetComponent<inputHandler>();

        
    
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void animState(animationState newState)
    {
        currentStates = newState;

        switch(currentStates)
        {

            case animationState.movement:
            {
              MoveAnim();
              break;
            } 

            case animationState.jump:
            {
              jump();
              break;
              
            } 
            case animationState.land:
            {
              landing();
              break;
              
            } 
            case animationState.roll:
            {
              rolling();
              break;
              
            } 
        }

}

void MoveAnim()
{
   float anifloat = Mathf.Abs(input_x.xAxis);
        Anim.SetFloat("movement",anifloat);
        Anim.SetBool("Isjumping",false);
         Anim.SetBool("isLanding",false);
          Anim.SetBool("roll",false);
} 

void jump( )
{
   //float anifloat = Mathf.Clamp(input_x.xAxis);
        //Anim.SetFloat("moviment",velocity_y);
    Anim.SetBool("Isjumping",true);
} 

void landing( )
{
   
    Anim.SetBool("isLanding",true);
    Anim.SetBool("Isjumping",false);
} 


void rolling( )
{
   
    Anim.SetBool("roll",true);
    //Anim.SetBool("Isjumping",false);
} 


}
