using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class VRTeleport : MonoBehaviour
{
    public Transform m_vRRig;
    public string m_buttonName;

    private LineRenderer m_line;
    private RaycastHit m_hit;
    private bool m_teleportValid;
    // Start is called before the first frame update
    void Start()
    {
        m_line = GetComponent<LineRenderer>();
        m_line.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton(m_buttonName))
        {
            if(Physics.Raycast(transform.position, transform.forward, out m_hit))
            {
                m_teleportValid = true;
                m_line.enabled = true;
                m_line.SetPosition(0, transform.position);
                m_line.SetPosition(1, m_hit.point);
            }
            else
            {
                m_teleportValid = false;
                m_line.enabled = false;
            }
        }
        else if(Input.GetButtonUp(m_buttonName))
        {
            m_line.enabled = false;
            if(m_teleportValid)
            {
                m_vRRig.position = m_hit.point;
            }
        }
    }
}
