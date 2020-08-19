using UnityEngine;
using UnityEngine.Serialization;

public class KinematicController : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * -speed * Time.deltaTime);
        }
        if(Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if(Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
}
