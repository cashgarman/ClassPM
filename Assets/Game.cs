using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Game : MonoBehaviour
{
    public LineRenderer path;
    public Castle castle;
    public Transform spawnPoint;
    public Enemy enemyPrefab;

    void Update()
    {
        UpdatePath();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            var enemy = Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
            enemy.game = this;
        }
    }

    private void UpdatePath()
    {
        path.SetPosition(0, castle.transform.position);
        path.SetPosition(1, spawnPoint.transform.position);
    }

    internal void OnCastleDamage(float damage)
    {
        castle.GetComponent<Castle>().health -= damage;

        // TODO: Handle the castle being destroyed
    }
}
