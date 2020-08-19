using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowerAI : MonoBehaviour
{
    public float m_turnSpeed = 4f;
    public float m_agroDistance = 10f;

    public Transform m_target;

    private NavMeshAgent m_agent;

    void Start()
    {
        m_agent = GetComponent<NavMeshAgent>();
        m_target = PlayerSingleton.s_instance.m_player;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(m_target.position , transform.position) < m_agroDistance)
        {
            m_agent.SetDestination(m_target.position);

            Vector3 dir = m_target.position - transform.position;
            dir.Normalize();
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * m_turnSpeed);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, m_agroDistance);
    }
}
