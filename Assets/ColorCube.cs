using System;
using UnityEngine;

public class ColorCube : MonoBehaviour
{
    public Color color;
    
    private Material material;

    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        material.color = color;
    }

    private void OnTriggerEnter(Collider other)
    {
        var strokePainter = other.GetComponent<StrokePainter>();
        if (strokePainter != null)
        {
            strokePainter.SetColor(color);
        }
    }
}
