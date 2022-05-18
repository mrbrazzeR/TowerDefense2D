using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDetail : MonoBehaviour
{
    public float attackRate = 0.5f;
    public float attackRange = 2f;
    public GameObject ending;
    public GameObject target;
    protected Animator animator;
    public Transform attackPoint;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public string enemyTag = "enemy";
    public int level;

    // Start is called before the first frame update
    protected void Start()
    {
        animator = GetComponent<Animator>();
        ending = GameObject.FindGameObjectWithTag("block_land");
        InvokeRepeating("Attack", 0f, attackRate);
        firePoint = GetComponent<Transform>();
        level = 0;
        target = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }     
    }
    protected virtual void Attack()
    {
        GameObject checksite = GameObject.FindGameObjectWithTag("checksite");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;

        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            float horizonToEnemy = transform.position.x - enemy.transform.position.x;
            float verticalToEnemy = transform.position.y - enemy.transform.position.y;
            float horizonToCheck = transform.position.x - checksite.transform.position.x;
            float verticalToCheck = transform.position.y - checksite.transform.position.y;
            float angle = 0f;
            float numerator = horizonToCheck * horizonToEnemy + verticalToCheck * verticalToEnemy;
            float denominator = Mathf.Sqrt(Mathf.Pow(horizonToCheck, 2) + Mathf.Pow(verticalToCheck, 2)) * Mathf.Sqrt(Mathf.Pow(horizonToEnemy, 2) + Mathf.Pow(verticalToEnemy, 2));
            if (distanceToEnemy < shortestDistance && distanceToEnemy <= attackRange)
            {
                angle = numerator / denominator;
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
            if (angle <= 0)
            {
                animator.SetBool("Attack", false);
                animator.SetBool("attackLeft", false);
                animator.SetBool("attackRight", true);
                animator.SetBool("Attack", true);

            }
            else if (angle > 0)
            {
                animator.SetBool("Attack", false);
                animator.SetBool("attackLeft", true);
                animator.SetBool("attackRight", false);
                animator.SetBool("Attack", true);
            }
        }
        if (nearestEnemy != null && shortestDistance <= attackRange)
        {
            target = nearestEnemy;
            animator.SetBool("Attack", true);
            addBullet();
        }
        else
        {
            target = null;
            animator.SetBool("Attack", false);
            animator.SetBool("attackLeft", false);
            animator.SetBool("attackRight", false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        if (target == null) return;
        Gizmos.DrawLine(transform.position, target.transform.position);
    }
    private void addBullet()
    {
        if(target == null) return;
        GameObject _bullet = Instantiate(bulletPrefab) as GameObject;
        _bullet.transform.position = firePoint.position;
        Bullet bullet = _bullet.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.Seek(target);
        }
        
    }
}
