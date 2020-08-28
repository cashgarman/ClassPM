using UnityEngine;
using Random = UnityEngine.Random;

public class SecondHand : MonoBehaviour
{
    public Clock clock;

    private void Start()
    {
        GetComponent<Animator>().Play("Secondhand", 0, Random.Range(0f, 1f));
    }

    public void OnMinutePassed()
    {
        clock.OnMinutePassed();
    }
}
