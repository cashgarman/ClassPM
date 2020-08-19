using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnDestroy : MonoBehaviour
{
    public GameObject explosionEffectPrefab;

    private void OnDestroy()
    {
        Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
    }
}
