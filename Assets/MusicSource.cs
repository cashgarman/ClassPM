using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class MusicSource : MonoBehaviour
{
    public AudioListener audioListener;
    public float maxDistance = 2.5f;
    public float minDistance = 0.8f;
    
    private ImageTargetBehaviour imageTarget;
    private AudioSource audioSource;
    private SphereCollider sphere;

    // Start is called before the first frame update
    void Start()
    {
        imageTarget = GetComponent<ImageTargetBehaviour>();
        audioSource = GetComponentInChildren<AudioSource>();
        audioSource.volume = 0f;
        sphere = GetComponentInChildren<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (imageTarget.CurrentStatus == TrackableBehaviour.Status.TRACKED)
        {
            var distance = Vector3.Distance(transform.position, audioListener.transform.position);
            var volume = Mathf.Lerp(0f, 1f, maxDistance - (distance + minDistance));
            // Debug.Log($"Volume of {name}: {volume}");
            audioSource.volume = volume;
            sphere.gameObject.SetActive(true);
        }
        else
        {
            audioSource.volume = 0f;
            sphere.gameObject.SetActive(false);
        }
    }
}
