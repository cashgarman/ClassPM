using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Xrayable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.renderQueue = 3002;
    }
}
