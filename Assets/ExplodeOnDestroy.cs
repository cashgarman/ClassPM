using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnDestroy : MonoBehaviour
{
    public GameObject explosionEffectPrefab;

    // Start is called before the first frame update
    private void OnDestroy()
    {
        Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
    }
}
