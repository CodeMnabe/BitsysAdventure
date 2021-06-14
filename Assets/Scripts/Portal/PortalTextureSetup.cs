using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour
{
    //If you want more portals you have to add more of this method here
    //Don't forget to make more materials and apply the shader to that material
    public Camera cameraB;
    public Material cameraMatB;

    public Camera cameraA;
    public Material cameraMatA;

    void Start()
    {
        if (cameraB)
        {
            if (cameraB.targetTexture != null)
            {
                cameraB.targetTexture.Release();
            }
            cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
            cameraMatB.mainTexture = cameraB.targetTexture;
        }
        

        if (cameraA)
        {
            if (cameraA.targetTexture != null)
            {
                cameraA.targetTexture.Release();
            }
            cameraA.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
            cameraMatA.mainTexture = cameraA.targetTexture;
        }
        
    }
}
