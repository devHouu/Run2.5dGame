using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PFG.core;

public class movementHandler : MonoBehaviour
{   
   //Velocity
    public float velocity = 5f;
    float speedSprite = 15;
    float currentSpeed;
    float currentRotation;
    ////////jump/////
    float jump = 280f;

    public float airCount =0f;
    public float air;


   public  bool isSprite;
  public   bool isRotate;
  public  bool Isgrounded;
  public bool check;

    // references
    inputHandler input;
    
    //Physics
    Rigidbody rb;
    animeController animController;


    void Start()
    {
        input = GetComponent<inputHandler>();
        rb = GetComponent<Rigidbody>();
        animController = GetComponent<animeController>();
        check = false;
        airCount =0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       

        Isgrounded = _graoundCheck();
         
         RunningFast(isSprite);

         if(check == true) return;

        Vector3 movement = new Vector2(input.xAxis,0f);

  
      if(_graoundCheck())
      {
        
           rb.velocity = new Vector2(movement.x*currentSpeed,rb.velocity.y);

              if(input.xAxis != 0)
             {

              Torotate();
              if(airCount==0)
              {
                animController.animState(animationState.movement);
                

              }
           
            
            } 
            if(airCount<1.4f) airCount=0f;

      } else
      {
        

         airCount+=Time.deltaTime;

        
      }

      

     if(input._Space&&_graoundCheck())
     {
        rb.AddForce(0,jump,0);
        animController.animState(animationState.jump);

     }
       ///estou repedindo rb.velocity.y < 0f demais , fazer metodo para corrigir
     if(rb.velocity.y < 0f)
     {     
          
            print(rb.velocity.y);
            if(_graoundCheck())
          {

            animController.animState(animationState.movement);
          }
          else{
            animController.animState(animationState.land);

          }
     }

    
            if(_graoundCheck()&& airCount >1.4f&&rb.velocity.y< 0f)
           {
           
            check  = true;
            StartCoroutine(stopLandingAnimation());
           }

        
          //else{
          //  animController.animState(animationState.land);

         // }
     
      
       
    }

   
   public  void Torotate()
    {
        Vector2 moverot = new Vector3(0f,0f,0f);

       if(input.xAxis<0){

            moverot.y = 180f;
       }    
       else {

           moverot.y = 0f;

            }
        transform.rotation = Quaternion.Slerp(transform.rotation,(Quaternion.Euler(moverot)),1f);

    }

   public void RunningFast( bool Fast )
   {

    if(Fast){currentSpeed=speedSprite;}   
    else{currentSpeed=velocity;}

   }


   public bool _graoundCheck()
   {
     RaycastHit hit;
    return (Physics.SphereCast(transform.position,.3f,-Vector3.up,out hit,.8f));
   }

    IEnumerator stopLandingAnimation()
    {
         animController.animState(animationState.roll);
        yield return new WaitForSeconds(.5f);
         airCount =0f;
        animController.animState(animationState.movement);
        check  = false;

    }



   void OnDrawGizmos()
   {

    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position+-Vector3.up*.8f,.3f);

   }



}
