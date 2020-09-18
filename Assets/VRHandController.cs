using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRHandController : MonoBehaviour
{
    private Animator animator;
    public string gripAxis;
    private bool isGripping;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Debug.Log($"{gripAxis}: {Input.GetAxis(gripAxis)}");
        
        if(Input.GetAxis(gripAxis) > 0.5f && !isGripping)
        {
            isGripping = true;
            animator.SetTrigger("Grip");
        }
        
        if (Input.GetAxis(gripAxis) < 0.5f && isGripping)
        {
            isGripping = false;
            animator.SetTrigger("Ungrip");
        }
    }
}
