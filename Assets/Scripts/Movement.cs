using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float m_moveSpeed = 3.5f;
    public float m_turnSpeed = 15;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        #region Translation
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * m_moveSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * m_moveSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * m_moveSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * m_moveSpeed * Time.deltaTime);
        }
        #endregion

        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * m_turnSpeed, Space.World);
        transform.Rotate(Vector3.left * Input.GetAxis("Mouse Y") * m_turnSpeed);
    }
}