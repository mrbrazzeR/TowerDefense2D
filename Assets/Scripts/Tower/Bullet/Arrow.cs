using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Bullet
{
    // Start is called before the first frame update
    void Start()
    {
        damage = 5;
        
        
    }   
    private void Update()
    {
        movingBullet();    
    }
    
}
