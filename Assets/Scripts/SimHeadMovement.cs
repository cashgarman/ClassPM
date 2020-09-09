using UnityEngine;

public class SimHeadMovement : MonoBehaviour
{
    public float m_moveSpeed = 3.5f;
    public float m_turnSpeed = 15;

    void Update()
    {
        // Handle movement using the keyboard
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

        // Rotate left and right based on the mouse X (in world space, so we don't spin around on the forward axis)
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * m_turnSpeed, Space.World);
        
        // Rotate up and down based on the mouse Y
        transform.Rotate(Vector3.left * Input.GetAxis("Mouse Y") * m_turnSpeed);
    }
}