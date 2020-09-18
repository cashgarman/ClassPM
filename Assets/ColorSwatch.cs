using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwatch : MonoBehaviour
{
    public Color color;

    void Start()
    {
        GetComponent<MeshRenderer>().material.color = color;
    }

    void Update()
    {
        
    }
}
