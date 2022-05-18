using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reptile : EnemySpawn
{
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 350;
        health = 350;
        currency = 7;
        score = 6;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
