using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBulletScript : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float shootForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
           GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint);
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce);
        }
    }
}
