using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PFG.core
{


    public class inputHandler : MonoBehaviour
{
   public float xAxis;
   public bool _shiftL;
   public bool _Space;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        xAxis= Input.GetAxis("Horizontal");
       if(Input.GetKeyDown(KeyCode.Space))
        {
             _Space = true;
        }
        else{
               _Space = false;
        }
    }
}

}
