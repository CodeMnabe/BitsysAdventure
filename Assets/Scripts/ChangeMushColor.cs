using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMushColor : MonoBehaviour
{
    [SerializeField] private GameObject objectToChange;
    [SerializeField] private Shader myShader;
    [SerializeField] private Texture myTexture;
    [SerializeField] private Color myColor;

    public int jumpHeight;
    private void Start()
    {
        Renderer rend = objectToChange.GetComponent<MeshRenderer>();

        rend.material = new Material(myShader);
        rend.material.mainTexture = myTexture;
        rend.material.color = myColor;
    }
}
