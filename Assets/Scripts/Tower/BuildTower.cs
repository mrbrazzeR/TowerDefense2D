using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTower : MonoBehaviour
{
    public Vector3 position;
    public List<GameObject> towerPrefab;
    public Collider2D col;
    public int numOfTower = 1;
    public int level = 0;
    public GameObject buildSystem;
    GameObject towerToBuild;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
        position = new Vector3(transform.position.x,transform.position.y+0.348f,transform.position.z);
        towerToBuild= null;
    }

    // Update is called once per frame
    void Update()
    {
        OpenChoose();
    }
    public void OpenChoose()
    {
        if (level >= 4)
            return;
        if (GameStats.stats == "resume")
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {

                Touch touch = Input.GetTouch(0);
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                if (touch.phase == TouchPhase.Began && col == Physics2D.OverlapPoint(touchPos))
                {
                    if (PlayerStats.Money >= 50)
                    {
                        if (gameObject == null)
                        {
                            towerToBuild = Instantiate(towerPrefab[level]) as GameObject;
                            level++;
                            towerToBuild.transform.position = position;
                            PlayerStats.Money -= 50;
                        }
                        if (gameObject != null)
                        {
                            Destroy(towerToBuild);
                            towerToBuild = Instantiate(towerPrefab[level]) as GameObject;
                            level++;
                            towerToBuild.transform.position = position;
                            PlayerStats.Money -= 50;
                        }
                    }
                }
            }
        }
    }
}

