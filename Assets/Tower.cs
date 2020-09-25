using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private List<Enemy> targets = new List<Enemy>();
    private bool shooting;
    private Enemy currentTarget;
    public Bullet bulletPrefab;
    public float reloadTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            var enemy = other.GetComponent<Enemy>();
            
            targets.Add(enemy);

            if (!shooting)
            {
                ShootAtNextTarget();
            }
            
            Debug.Log($"Saw a new enemy {enemy.name}");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            var enemy = other.GetComponent<Enemy>();
            
            targets.Remove(enemy);
            
            Debug.Log($"Lost sight of an enemy {enemy.name}");
        }
    }

    private void ShootAtNextTarget()
    {
        currentTarget = targets.LastOrDefault();
        if (currentTarget != null)
        {
            Debug.Log($"Shooting at {currentTarget.name}");
            StartCoroutine(StartShootingAtEnemy(currentTarget.GetComponent<Enemy>()));
        }
    }

    private IEnumerator StartShootingAtEnemy(Enemy target)
    {
        // Now the tower is shooting
        shooting = true;
        
        while (target.health > 0 && targets.Contains(target))
        {
            // Spawn a bullet
            Debug.Log($"Shooting at {target.name}");
            var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity).GetComponent<Bullet>();
            bullet.target = target;
        
            // Wait for the tower to reload
            yield return new WaitForSeconds(reloadTime);
        }

        // Now the target is dead, remove is from the list
        targets.Remove(target);
        shooting = false;
        ShootAtNextTarget();
    }
}