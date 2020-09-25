using UnityEngine;

public class Bullet : MonoBehaviour
{
	public Enemy target;
	public float speed;
	public float reachedTargetThresholdhold;
	public float damage;

	private void Update()
	{
		var direction = (target.transform.position - transform.position).normalized;
		transform.position += direction.normalized * speed * Time.deltaTime;

		if (Vector3.Distance(transform.position, target.transform.position) < reachedTargetThresholdhold)
		{
			target.OnDamage(damage);
			Destroy(gameObject);
		}
	}
}