using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitGun : MonoBehaviour
{
    public GameObject m_prefabBit;
    public Transform m_spawn;
    public float m_shootForce;

    private Coroutine m_shootCoroutine;

    void TriggerDown()
    {
        m_shootCoroutine = StartCoroutine(SpamShoot());
    }

    void TriggerUp()
    {
        StopCoroutine(m_shootCoroutine);
    }

    IEnumerator SpamShoot()
    {
        while(true)
        {
            GameObject bit = Instantiate(m_prefabBit, m_spawn.position, m_spawn.rotation);

            bit.GetComponent<Rigidbody>().AddForce(m_spawn.forward * m_shootForce);

            Destroy(bit, 5f);

            yield return new WaitForSeconds(0.25f);
        }

    }
}
