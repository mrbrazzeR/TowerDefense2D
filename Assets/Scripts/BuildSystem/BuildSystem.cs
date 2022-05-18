using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSystem : MonoBehaviour
{   
    public GameObject towerPrefab;
    public BoxCollider2D col;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        BuildTower();
    }
    public void BuildTower()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {

            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            if (touch.phase == TouchPhase.Began&& col == Physics2D.OverlapPoint(touchPos))
            {
                GameObject towerToBuild= GameObject.Instantiate(towerPrefab);   
                towerToBuild.transform.position = transform.position; 
            }
        }
    }
}
