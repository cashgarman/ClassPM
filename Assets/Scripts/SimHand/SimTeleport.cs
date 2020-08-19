using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class SimTeleport : MonoBehaviour
{
    private LineRenderer m_line;
    private bool m_teleportValid;
    private RaycastHit m_hit;

    private void Start()
    {
        m_line = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.T))
        {
            if(Physics.Raycast(transform.position, transform.forward, out m_hit))
            {
                m_line.enabled = true;
                m_line.SetPosition(0, transform.position);
                m_line.SetPosition(1, m_hit.point);
                m_teleportValid = true;
            }
            else
            {
                m_line.enabled = false;
                m_teleportValid = false;
            }
        }
        else if(Input.GetKeyUp(KeyCode.T))
        {
            m_line.enabled = false;
            if(m_teleportValid)
            {
                transform.position = m_hit.point;
            }
        }
    }
}
