using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSnake : EnemySpawn
{
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 150;
        health = 150;
        currency = 5;
        score = 4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
