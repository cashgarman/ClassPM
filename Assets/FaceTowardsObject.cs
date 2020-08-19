using UnityEngine;

public class FaceTowardsObject : MonoBehaviour
{
    public Transform target;
    
    void Update()
    {
        transform.LookAt(target);
    }
}
