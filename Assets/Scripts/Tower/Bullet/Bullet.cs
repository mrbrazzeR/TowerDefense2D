using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject target;
    public float speed = 3f;
    public int damage;
    public int baseDamage;
    public int level;
    // Start is called before the first frame update
    private void Start()
    {
        level = 0;
        damage = 0;
        baseDamage = 0;
    }
    // Update is called once per frame
    public void Update()
    {
        movingBullet();
    }
    public void Seek(GameObject _target)
    {
        target = _target;
    }
    public void hitTarget()
    {
        target.gameObject.GetComponent<EnemySpawn>().TakeDamage(damage);
        Destroy(gameObject);
    }
    public void movingBullet()
    {      
        if (target == null)
        {   
            
            Destroy(gameObject);
            return;
        }
        Vector3 direction = target.transform.position - transform.position;
        float distance = speed * Time.deltaTime;
        if (direction.magnitude <= distance)
        {           
            hitTarget();
            return;
        }
        transform.Translate(direction.normalized * distance, Space.World);
    }
    

}
