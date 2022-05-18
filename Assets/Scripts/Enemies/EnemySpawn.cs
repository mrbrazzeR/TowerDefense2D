using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour
{
    //wave detail
    public float spawnTime = 0.5f;
    public float cooldown = 0.5f;
    public float nextWaveTime = 10f;
    public float nextTime = 30f;
    //num of wave
    [SerializeField] int min;
    [SerializeField] int max;
    [SerializeField] int spawnCount = 0;
    [SerializeField] int spawnMax;
    [SerializeField] int currentType;
    public int waveCount;
    public List<GameObject> enemyList;
    public List<GameObject> spawnList;

    //enemy Status
    protected float health;
    protected int currency;
    protected int score;
    protected float maxHealth;

    public Image healthBar;

  // Start is called before the first frame update
    void Start()
    {
        min = 5;
        max = 10;
        spawnMax = Random.Range(min, max);
        waveCount = 1;
        spawnList = new List<GameObject>();
        currentType = 1;
    }

    // Update is called once per frame
    void Update()
    {
       StartCoroutine(spawnWave());
    }
    
    private void countNextWave()
    {
        if(nextWaveTime<=0f)
        {
            nextWaveTime = nextTime;
            cooldown = 0f;
            min =spawnMax;
            max =min+Random.Range(3,8);
            waveCount++;
            spawnMax= Random.Range(min,max);
            spawnCount = 0;
        }
        if(waveCount==5)
        {
            currentType = 2;
            nextTime = 8f;
        }
        if(waveCount==9)
        {
            currentType = 3;
            nextTime = 5f;
        }
        if(waveCount>15)
        {
            currentType = enemyList.Count - 1;
            nextTime = 2f;
        }
        nextWaveTime -= Time.deltaTime;
    }
    IEnumerator spawnWave()
    {
        if (spawnList.Count < currentType)
        {
            spawnList.Add(enemyList[Random.Range(0, currentType)]);
        }
        if (cooldown <= 0f&&spawnCount<spawnMax)
        {
                
            { 
                spawnEnemy();               
                spawnCount++;
            }
            cooldown = spawnTime;
            
            yield return new WaitForSeconds(spawnTime);
        }
        if(spawnCount==spawnMax)
        {
            countNextWave();
            spawnList.Clear();
        }
        cooldown -= Time.deltaTime;
    }
    protected virtual void spawnEnemy()
    {

                GameObject enemy = Instantiate(spawnList[Random.Range(0,spawnList.Count-1)]) as GameObject;
                enemy.transform.position = new Vector3(-4.116f, -0.929f, 0);
    }       
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health<=0)
        {
            Destroy(gameObject);
            PlayerStats.Money += currency;
            PlayerStats.Score += score;
        }    
        healthBar.fillAmount = health/maxHealth;
    }
    
   
}
