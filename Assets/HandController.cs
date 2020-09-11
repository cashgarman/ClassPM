using UnityEngine;

public class HandController : MonoBehaviour
{
    private Animator animator;
    private bool isGripped;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isGripped)
        {
            animator.SetTrigger("Grip");
            isGripped = true;
        }

        if (Input.GetKeyUp(KeyCode.Space) && isGripped)
        {
            animator.SetTrigger("Ungrip");
            isGripped = false;
        }
    }
}
