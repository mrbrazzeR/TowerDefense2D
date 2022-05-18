using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : EnemySpawn
{
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 100;
        health = 100;
        currency = 3;
        score = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
}
