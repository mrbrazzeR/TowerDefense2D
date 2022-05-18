using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public static int Score;
    public static int Health;
    public int startMoney = 150;
    public int startScore = 0;
    public int startHealth = 20;
    // Start is called before the first frame update
    void Start()
    {
        Money = startMoney;
        Score = startScore;
        Health = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
    }
    
}
