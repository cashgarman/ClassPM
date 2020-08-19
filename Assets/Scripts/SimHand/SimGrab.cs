using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimGrab : MonoBehaviour
{
    public Animator m_anim;

    private GameObject m_touchingObject;
    private GameObject m_heldObject;

    private Vector3 m_handVelocity;
    private Vector3 m_oldPosition;

    private Vector3 m_handAngularVelocity;
    private Vector3 m_oldEulerAngles;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Interactable")
        {
            m_touchingObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(m_touchingObject == other.gameObject)
        {
            m_touchingObject = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tp = transform.position;
        m_handVelocity = tp - m_oldPosition;
        m_oldPosition = tp;

        Vector3 te = transform.eulerAngles;
        m_handAngularVelocity = te - m_oldEulerAngles;
        m_oldEulerAngles = te;

        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            m_anim.SetBool("isGrabbing", true);
            if(m_touchingObject)
            {
                Grab();
            }
        }

        if(Input.GetKeyUp(KeyCode.Mouse1))
        {
            m_anim.SetBool("isGrabbing", false);
            if(m_heldObject)
            {
                m_heldObject.SendMessage("GrabReleased");
                Release();
            }
        }

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(m_heldObject)
            {
                m_heldObject.SendMessage("TriggerDown");
            }
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if(m_heldObject)
            {
                m_heldObject.SendMessage("TriggerUp");
            }
        }

        if(Input.GetKeyDown(KeyCode.Mouse2))
        {
            if(m_heldObject)
            {
                m_heldObject.SendMessage("MenuDown");
            }
        }
    }

    void Grab()
    {
        if(m_touchingObject.GetComponent<Rigidbody>().mass > 10)
        {
            return;
        }

        m_heldObject = m_touchingObject;
        m_heldObject.GetComponent<Rigidbody>().isKinematic = true;
        m_heldObject.transform.SetParent(transform);

        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.connectedBody = m_heldObject.GetComponent<Rigidbody>();
        fx.axis = transform.forward;
        fx.breakForce = 5000;
        fx.breakTorque = 5000;
    }

    void Release()
    {
        m_heldObject.transform.SetParent(null);
        m_heldObject.GetComponent<Rigidbody>().isKinematic = false;
        Destroy(GetComponent<FixedJoint>());

        Rigidbody rb = m_heldObject.GetComponent<Rigidbody>();
        rb.velocity = m_handVelocity * 60/rb.mass;
        rb.angularVelocity = m_handAngularVelocity * 60 / rb.mass;

        m_heldObject = null;
    }

    private void OnJointBreak(float breakForce)
    {
        m_heldObject.SendMessage("GrabReleased");
        m_heldObject.transform.SetParent(null);
        m_heldObject = null;
    }
}
