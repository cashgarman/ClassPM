using UnityEngine;

public class RigidBodyController : MonoBehaviour
{
    public float force;
    // public Rigidbody rigidBody;
    private Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            // Rigidbody objects
            rigidBody.AddForce(Vector3.forward * force);
        }
        if(Input.GetKey(KeyCode.S))
        {
            // Rigidbody objects
            rigidBody.AddForce(Vector3.forward * -force); // Explain the negative part here
        }
        if(Input.GetKey("a"))
        {
            // Rigidbody objects
            rigidBody.AddForce(Vector3.left * force);
        }
        if(Input.GetKey("d"))
        {
            // Rigidbody objects
            rigidBody.AddForce(Vector3.right * force);
        }
    }
}
