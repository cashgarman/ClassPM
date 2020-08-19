using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TouchButton : MonoBehaviour
{
    public UnityEvent m_buttonPressed;
    public UnityEvent m_buttonReleased;

    public Transform m_upTransform;
    public Transform m_downTransform;
    public Transform m_buttonMesh;

    private void OnTriggerEnter(Collider other)
    {
        m_buttonMesh.position = m_downTransform.position;
        m_buttonPressed.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        m_buttonMesh.position = m_upTransform.position;
        m_buttonReleased.Invoke();
    }
}
