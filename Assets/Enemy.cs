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
    private Animator animator;
    public float health;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!attacking)
        {
            var direction = (game.castle.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            distanceToCastle = Vector3.Distance(game.castle.transform.position, transform.position);
            
            // Rotate the enemy to face the castle
            transform.LookAt(game.castle.transform.position);
            
            animator.SetFloat("MoveSpeed", 1f);
        }

        if(!attacking && distanceToCastle < attackingDistance)
        {
            attacking = true;
            animator.SetFloat("MoveSpeed", 0f);

            StartCoroutine(StartAttacking());
        }
    }

    private IEnumerator StartAttacking()
    {
        while(true)
        {
            animator.SetTrigger("Attack");
            game.OnCastleDamage(damage);

            yield return new WaitForSeconds(attackDelay);
        }
    }

    public void OnDamage(float damage)
    {
        Debug.Log($"{name} took {damage} damage");
        health -= damage;
	
        if (health <= 0f)
        {
            Debug.Log($"{name} died");
            Destroy(gameObject);
        }
    }
}
