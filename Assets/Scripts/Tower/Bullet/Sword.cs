using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Bullet
{
    // Start is called before the first frame update
    void Start()
    {
        damage = 31;

    }
    // Update is called once per frame
    private void Update()
    {
        movingBullet();
    }
    
}
