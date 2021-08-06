using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShader : MonoBehaviour
{
    //大概是镜子的反射类？妈的这样写谁看得懂？操你妈 F U C K Y O U
    public Material material;
    private void OnRenderImage(RenderTexture source,RenderTexture destination){
        Graphics.Blit(source, destination, material);
    }
}
