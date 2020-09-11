using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class MusicSource : MonoBehaviour
{
    private ImageTargetBehaviour imageTarget;
    private AudioSource audioSource;

    public AudioListener audioListener;

    void Start()
    {
        imageTarget = GetComponent<ImageTargetBehaviour>();
        audioSource = GetComponentInChildren<AudioSource>();
        audioSource.volume = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(imageTarget.CurrentStatus == TrackableBehaviour.Status.TRACKED)
        {
            audioSource.volume = 1f;

            var distance = Vector3.Distance(transform.position, audioListener.transform.position);
            Debug.Log(distance);
        }
        else
        {
            audioSource.volume = 0f;
        }
    }
}
