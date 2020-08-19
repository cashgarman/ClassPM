using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLocomotion : MonoBehaviour
{
    public string m_horizontal;
    public string m_vertical;

    public Transform m_vRRig;
    public Transform m_director;
    public Transform m_vRHead;
    public LayerMask m_groundLayer;
    

    // Update is called once per frame
    void Update()
    {
        Vector2 touchPosition;
        touchPosition.x = Input.GetAxis(m_horizontal);
        touchPosition.y = Input.GetAxis(m_vertical);
        //touchPosition.Normalize();
        Vector3 playerRight = touchPosition.x * m_director.right;
        Vector3 playerForward = touchPosition.y * m_director.forward;

        playerRight.y = 0;
        playerForward.y = 0;

        m_vRRig.position += playerRight * Time.deltaTime;
        m_vRRig.position += playerForward * Time.deltaTime;

        m_vRRig.position = new Vector3(m_vRRig.position.x, GetGroundHeight(), m_vRRig.position.z);
    }

    float GetGroundHeight()
    {
        RaycastHit hit;
        if(Physics.Raycast(m_vRHead.position, Vector3.down, out hit, 100, m_groundLayer))
        {
            return hit.point.y;
        }
        return m_vRRig.position.y;
    }
}
