// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//
// public class VRHand : MonoBehaviour
// {
//     public Animator m_anim;
//
//     public string m_gripName;
//     private bool m_gripHeld;
//
//     public string m_triggerName;
//     private bool m_triggerHeld;
//
//     public string m_menuButtonName;
//
//     private Vector3 m_handVelocity;
//     private Vector3 m_oldPosition;
//
//     private Vector3 m_handAngularVelocity;
//     private Vector3 m_oldEulerAngles;
//
//     private GameObject m_touchingObject;
//     private GameObject m_heldObject;
//
//     private void OnTriggerStay(Collider other)
//     {
//         if(other.tag == "Interactable")
//         {
//             m_touchingObject = other.gameObject;
//         }
//     }
//
//     private void OnTriggerExit(Collider other)
//     {
//         m_touchingObject = null;
//     }
//
//     void Update()
//     {
//         Vector3 tp = transform.position;
//         m_handVelocity = tp - m_oldPosition;
//         m_oldPosition = tp;
//
//         Vector3 te = transform.eulerAngles;
//         m_handAngularVelocity = te - m_oldEulerAngles;
//         m_oldEulerAngles = te;
//
//         if(Input.GetAxis(m_gripName) > 0.5f && !m_gripHeld)
//         {
//             m_gripHeld = true;
//             m_anim.SetBool("isGrabbing", true);
//             if(m_touchingObject)
//             {
//                 Grab();
//             }
//         }
//         else if(Input.GetAxis(m_gripName) < 0.5f && m_gripHeld)
//         {
//             m_gripHeld = false;
//             m_anim.SetBool("isGrabbing", false);
//             if(m_heldObject)
//             {
//                 m_heldObject.SendMessage("GrabReleased");
//                 Release();
//             }
//         }
//
//         if(Input.GetAxis(m_triggerName) > 0.8f && !m_triggerHeld)
//         {
//             m_triggerHeld = true;
//             if(m_heldObject)
//             {
//                 m_heldObject.SendMessage("TriggerDown");
//             }
//         }
//         else if(Input.GetAxis(m_triggerName) < 0.8f && m_triggerHeld)
//         {
//             m_triggerHeld = false;
//             if(m_heldObject)
//             {
//                 m_heldObject.SendMessage("TriggerUp");
//             }
//         }
//
//         if(Input.GetButtonD	own(m_menuButtonName))
//         {
//             if(m_heldObject)
//             {
//                 m_heldObject.SendMessage("MenuDown");
//             }
//         }
//     }
//
//     void Grab()
//     {
//         m_heldObject = m_touchingObject;
//         //m_heldObject.GetComponent<Rigidbody>().isKinematic = true;
//
//         FixedJoint fx = gameObject.AddComponent<FixedJoint>();
//         fx.connectedBody = m_heldObject.GetComponent<Rigidbody>();
//         fx.breakForce = 5000;
//         fx.breakTorque = 5000;
//
//         m_heldObject.transform.SetParent(transform);
//     }
//
//     void Release()
//     {
//         //m_heldObject.GetComponent<Rigidbody>().isKinematic = false;
//         Destroy(GetComponent<FixedJoint>());
//         m_heldObject.transform.SetParent(null);
//
//         Rigidbody rb = m_heldObject.GetComponent<Rigidbody>();
//         rb.velocity = m_handVelocity * 60 / rb.mass;
//         rb.angularVelocity = m_handAngularVelocity * 60 / rb.mass;
//
//         m_heldObject = null;
//     }
//
//     private void OnJointBreak(float breakForce)
//     {
//         m_heldObject.SendMessage("GrabReleased");
//         m_heldObject.transform.SetParent(null);
//         m_heldObject = null;
//     }
// }
