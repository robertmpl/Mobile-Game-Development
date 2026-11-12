using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    [SerializeField] private float damage = 1f;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float range = 5f;

    private GameObject target;
    
    private float nextAttackTime;

    void Start()
    {
        nextAttackTime = Time.time + fireRate;
    }

    void GetClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        float closestRange = range;
        target = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);

            if (distance < closestRange)
            {
                closestRange = distance;
                target = enemy;
            }
        }
    }

    void AttackEnemy()
    {
        EnemyHealth enemyHealth = target.GetComponent<EnemyHealth>();

        if (enemyHealth)
        {
            RotateToEnemy();
            enemyHealth.TakeDamage(damage);
        }
    }

    void RotateToEnemy()
    {
        Vector2 enemyDirection = target.transform.position - transform.position;
        float angle = Mathf.Atan2(enemyDirection.y, enemyDirection.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    void Update()
    {

        if (Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + fireRate;

            GetClosestEnemy();

            if (target)
            {
                AttackEnemy();
            }
        }

    }
}
