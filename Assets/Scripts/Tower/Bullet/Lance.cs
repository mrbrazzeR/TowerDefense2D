using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lance : Bullet
{
    // Start is called before the first frame update
    void Start()
    {
        damage = 10;
      
    }
    // Update is called once per frame
    private void Update()
    {
        movingBullet();
    }
    
}
