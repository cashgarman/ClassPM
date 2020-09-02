using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRHandController : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Grip");
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetTrigger("Ungrip");
        }
    }
}
