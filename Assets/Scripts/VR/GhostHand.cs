using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostHand : MonoBehaviour
{
    public Transform m_hand;

    private Color m_ghostColor;
    public Renderer m_ghostHandRend;

    private bool m_isTracking = true;

    // Start is called before the first frame update
    void Start()
    {
        m_ghostColor = m_ghostHandRend.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        m_ghostColor.a = Vector3.Distance(transform.position, m_hand.position);
        m_ghostHandRend.material.color = m_ghostColor;

        if(m_isTracking)
        {
            m_hand.position = transform.position;
            m_hand.rotation = transform.rotation;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.isStatic)
        {
            m_isTracking = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.isStatic)
        {
            m_isTracking = true;
        }
    }
}
