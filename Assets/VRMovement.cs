using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRMovement : MonoBehaviour
{
    public string forwardInput;
    public Transform headTransform;

    void Update()
    {
        if (Input.GetAxis(forwardInput) != 0)
        {
            // Move the VRRoot forward in the direction the VRHead is facing
            transform.parent.Translate(headTransform.forward * -Input.GetAxis(forwardInput) * Time.deltaTime);
        }
    }
}
