using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotchedLever : MonoBehaviour
{
    public Transform m_startNotch;
    public Transform m_endNotch;

    public float m_notchSpeed;

    public List<Transform> m_notches = new List<Transform>();

    private Transform m_closestNotch;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            m_closestNotch = null;

            Vector3 heading = m_endNotch.position - m_startNotch.position;
            float magnitudeOfHeading = heading.magnitude;
            heading.Normalize();

            Vector3 startToHand = other.transform.position - m_startNotch.position;
            float dotProduct = Vector3.Dot(startToHand, heading);
            dotProduct = Mathf.Clamp(dotProduct, 0, magnitudeOfHeading);
            Vector3 spot = m_startNotch.position + heading * dotProduct;

            transform.position = spot;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            m_closestNotch = m_startNotch;

            foreach(var notch in m_notches)
            {
                if(Vector3.Distance(transform.position, notch.position) < Vector3.Distance(transform.position, m_closestNotch.position))
                {
                    m_closestNotch = notch;
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(m_closestNotch)
        {
            transform.position = Vector3.MoveTowards(transform.position, m_closestNotch.position, m_notchSpeed);
        }
    }
}
