using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paintbrush : MonoBehaviour
{
    private Color currentColor;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        var swatch = other.GetComponent<ColorSwatch>();
        if(swatch != null)
        {
            SetColor(swatch.color);
        }
    }

    private void SetColor(Color color)
    {
        currentColor = color;
        GetComponent<MeshRenderer>().material.color = color;
    }
}
