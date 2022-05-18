using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI coin;
    public TextMeshProUGUI wave;
    public TextMeshProUGUI health;
    private int totalCoin;
    private int totalScore;
    private int totalWave;
    private int totalHealth;
    public GameObject enemyManager;
    public static ScoreManager instance;
    [SerializeField] GameObject endMenu;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        instance = this;
        if(instance!=null)
        {
            return;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totalWave = enemyManager.GetComponent<EnemySpawn>().waveCount;
        wave.text = "Wave: "+totalWave.ToString();
        totalScore = PlayerStats.Score;
        score.text = "Score: "+totalScore.ToString();
        totalCoin = PlayerStats.Money;
        coin.text = totalCoin.ToString();
        totalHealth = PlayerStats.Health;
        health.text = totalHealth.ToString();
        endGame();
    }
    public void endGame()
    {
        
        if(totalHealth<=0)
        {
            endMenu.SetActive(true);
        }
    }
}
