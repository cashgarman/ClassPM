using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    internal Game game;
    public float speed;
    public float distanceToCastle;
    public float attackingDistance;
    public float damage;
    public float attackDelay;

    private bool attacking;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!attacking)
        {
            var direction = (game.castle.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            distanceToCastle = Vector3.Distance(game.castle.transform.position, transform.position);
        }

        if(!attacking && distanceToCastle < attackingDistance)
        {
            attacking = true;

            StartCoroutine(StartAttacking());
        }
    }

    private IEnumerator StartAttacking()
    {
        while(true)
        {
            game.OnCastleDamage(damage);

            yield return new WaitForSeconds(attackDelay);
        }
    }
}
