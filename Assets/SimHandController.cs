using UnityEngine;

public class SimHandController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float rotateSpeed = 100f;

    public GameObject collidingObject;
    public GameObject heldObject;
    
    private Color originalCollidingObjectColor;
    private Animator animator;

    void Start()
    {
        // animator = GetComponent<Animator>();
        
        // Lock the cursor in the middle of the screen and make it invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (collidingObject != null)
        {
            return;
        }
        
        collidingObject = other.gameObject;
        originalCollidingObjectColor = collidingObject.GetComponent<MeshRenderer>().material.color;
        collidingObject.GetComponent<MeshRenderer>().material.color = Color.red;
    }

    private void OnTriggerExit(Collider other)
    {
        // Is the object that was just exited the previously colliding object?
        if(other.gameObject == collidingObject)
        {
            // If so, restore its original colour and reset the currently colliding object
            collidingObject.GetComponent<MeshRenderer>().material.color = originalCollidingObjectColor;
            collidingObject = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) // Left mouse button down
        {
            // Play the gripping animation
            // animator.SetTrigger("Grip");
            
            GrabObject();
        }
        else if (Input.GetMouseButtonUp(0)) // Left mouse button up
        {
            // Play the ungripping animation
            // animator.SetTrigger("Ungrip");
            
            ReleaseObject();
        }
    }

    private void GrabObject()
    {
        if(collidingObject != null)
        {
            collidingObject.transform.SetParent(transform);
            heldObject = collidingObject;
            heldObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    private void ReleaseObject()
    {
        if (heldObject != null)
        {
            heldObject.transform.SetParent(null);
            heldObject.GetComponent<Rigidbody>().isKinematic = false;
            heldObject = null;
        }
    }
}
