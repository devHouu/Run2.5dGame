using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScaler : MonoBehaviour
{
    
    void Start()
    {
         RenderTexture rt = new RenderTexture(320, 240, 24);

    // Configurar a câmera principal para renderizar na textura
    Camera.main.targetTexture = rt;
        
    }

    
}
