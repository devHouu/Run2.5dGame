using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PFG.core
{
    public class CameraPlayer : MonoBehaviour
{
     Transform player;
     public Vector3 zDistance;
     public Vector3 velocidade;

     
    // Start is called before the first frame update
    void Start()
    {
        if(player==null)
          player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

     
    }

    // Update is called once per frame
    void Update()
    {
        float distX =Mathf.Abs(player.position.x-transform.position.x);
        float distY =Mathf.Abs(player.position.y-transform.position.y);

        if(distX >1f||distY >1f)
          transform.position = Vector3.SmoothDamp(transform.position,player.position+zDistance,
            ref velocidade,2f) ;
      
       
        
    }
}

}
