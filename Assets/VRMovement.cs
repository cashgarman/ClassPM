using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRMovement : MonoBehaviour
{
    public string forwardInput;

    void Update()
    {
        if (Input.GetAxis(forwardInput) != 0)
        {
            // Move the VRRoot forward in the direction the VRHead is facing
            transform.parent.Translate(transform.forward * -Input.GetAxis(forwardInput) * Time.deltaTime);
        }
    }
}
