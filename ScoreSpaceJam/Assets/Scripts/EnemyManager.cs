using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Fields
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private GameObject nextRoom;

    [SerializeField]
    private GameObject currentRoom;

    [SerializeField]
    private int totalNumberEnemies = 5;

    int numberSpawned;
    int numberKilled;
    float theta;

    List<GameObject> enemyList = new List<GameObject>();
    

    // Property
    public List<GameObject> EnemyList
    {
        get { return enemyList; }
        set { enemyList = value; }
    }

    // Update is called once per frame
    void Update()
    {
        if (numberSpawned < totalNumberEnemies)
        {
            for (int i = 0; i < totalNumberEnemies; i++)
            {
                MakeEnemy();
                numberSpawned++;
            }
        }
        foreach (GameObject enemy in enemyList)
        {
            if(enemy == null)
            {
                RemoveEnemy(enemy);
            }
            else
            {
                return;
            }
            
        }
        if(numberKilled == numberSpawned)
        {
            enemyList.Clear();
        }
        if (enemyList.Count == 0)
        {
            nextRoom.SetActive(true);
            Destroy(currentRoom);
        }
    }

    public void MakeEnemy()
    {
        enemyPrefab = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        enemyList.Add(enemyPrefab);
    }

    public void RemoveEnemy(GameObject enemy)
    {
        enemyList.Remove(enemy);
        numberKilled++;
    }

}
