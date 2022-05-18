using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : EnemySpawn
{
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 50;
        health = 50;
        currency = 2;
        score = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
