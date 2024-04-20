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
    private int totalNumberEnemies = 5;

    
    int numberSpawned;
    int numberKilled;
    float theta;


    List<Enemy> enemyList = new List<Enemy>();
    

    // Property
    public List<Enemy> EnemyList
    {
        get { return enemyList; }
        set { enemyList = value; }
    }

    // Methods
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (numberSpawned < totalNumberEnemies)
        {
            for (int i = 0; i < totalNumberEnemies; i++)
            {
                Vector3 vector3 = new Vector3(2f * i, 2f * i, 0);
                MakeEnemy(vector3);
                numberSpawned++;
            }
        }
        if (numberSpawned == totalNumberEnemies && enemyList.Count == 0)
        {
            nextRoom.SetActive(true);
        }
        if(numberKilled == numberSpawned)
        {
            enemyList.Clear();
        }
    }

    public void MakeEnemy(Vector2 position)
    {
        Enemy enemy = new Enemy();
        Instantiate(enemyPrefab, transform.position * position, Quaternion.identity);
        enemyList.Add(enemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        enemyList.Remove(enemy);
        numberKilled++;
    }

}
