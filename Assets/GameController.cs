using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject ballPrefab;
    public BoxCollider gameArea;

    // Start is called before the first frame update
    void Start()
    {
        SpawnBall();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.tag == "Ball")
                {
                    Destroy(hit.collider.gameObject);

                    SpawnBall();
                }
            }
        }
    }

    private void SpawnBall()
    {
        Instantiate(ballPrefab, GetRandomBallPosition(), Quaternion.identity);
    }

    private Vector3 GetRandomBallPosition()
    {
        Bounds bounds = gameArea.bounds;

        return new Vector3(UnityEngine.Random.Range(bounds.min.x, bounds.max.x),
            UnityEngine.Random.Range(bounds.min.y, bounds.max.y),
            UnityEngine.Random.Range(bounds.min.z, bounds.max.z));
    }
}
