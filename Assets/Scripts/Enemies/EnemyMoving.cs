using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    float speed = 1f;
    public bool status;
    Vector3 jumpOtherLand;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();    
        status = true;
        jumpOtherLand = new Vector3(0,1.45f,0);
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }
    void Moving()
    {
        if(status)
        {
            transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
            animator.SetBool("movingRight", true);
            animator.SetBool("movingLeft", false);
        }
        else if(!status)
        {
            transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
            animator.SetBool("movingLeft", true);
            animator.SetBool("movingRight", false);
        }
    }
    void changeStatus()
    {
        if(status)
        {
            status = false;
            
            transform.localPosition = transform.localPosition+jumpOtherLand;
        }
        else if(!status)
        {
             status=true;          
           
            transform.localPosition = transform.localPosition + jumpOtherLand;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("block_land"))
        {
            changeStatus();
        }
        if(collision.collider.CompareTag("destroy"))
        {
            PlayerStats.Health--;
            Destroy(gameObject);
        }
    }
}
