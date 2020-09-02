using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHandController : MonoBehaviour
{
    public float moveSpeed = 2f;

    public float rotateSpeed = 100f;

    public GameObject collidingObject;

    public GameObject heldObject;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        collidingObject = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == collidingObject)
        {
            collidingObject = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            GrabObject();
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            ReleaseObject();
        }

        #region Movement Functions

        if (Input.GetKey(KeyCode.W)) // Forward
        {
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
        }
        if(Input.GetKey(KeyCode.S)) // Backeard
        {
            transform.position -= transform.forward * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.A)) // Left
        {
            transform.position -= transform.right * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.D)) // Right
        {
            transform.position += transform.right * Time.deltaTime * moveSpeed;
        }
        if(Input.GetKey(KeyCode.Q)) // Up
        {
            transform.position += transform.up * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.E)) // Down
        {
            transform.position -= transform.up * Time.deltaTime * moveSpeed;
        }

        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed, Space.World);
        transform.Rotate(Vector3.left, Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSpeed, Space.Self);

        #endregion
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
        if (heldObject)
        {
            heldObject.transform.SetParent(null);

            heldObject.GetComponent<Rigidbody>().isKinematic = false;

            heldObject = null;
        }
    }
}
