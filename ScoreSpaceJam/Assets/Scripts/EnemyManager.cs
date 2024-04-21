using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
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
        // Spawns a certain number of enemies
        if (numberSpawned < totalNumberEnemies)
        {
            for (int i = 0; i < totalNumberEnemies; i++)
            {
                MakeEnemy();
                numberSpawned++;
            }
        }
        // Removes enemies who are null from the list
        for (int i = 0; i < enemyList.Count; i++)
        {
            if (enemyList[i] == null)
            {
                RemoveEnemy(enemyList[i]);
            }
            else
            {
                return;
            }
            
        }
        // Clears list once all enemies are dead
        if(numberKilled == numberSpawned)
        {
            enemyList.Clear();
        }
        // actovates next room and destroys the current room
        if (enemyList.Count == 0)
        {
            nextRoom.SetActive(true);
            Destroy(currentRoom);
        }
    }

    // Creates an enemy at a specified location
    public void MakeEnemy()
    {
        Vector2 position = EnemyLocations();
        enemyPrefab = Instantiate(enemyPrefab, position, Quaternion.identity);
        enemyList.Add(enemyPrefab);
    }

    // Removes dead enemies from the list
    public void RemoveEnemy(GameObject enemy)
    {
        enemyList.Remove(enemy);
        numberKilled++;
    }

    // Specifies enemy locations
    Vector2 EnemyLocations()
    {
        Vector2 enemyVector = new Vector2();
        float radius = Random.Range(1f, 3f);
        float theta = 2 * Mathf.PI / totalNumberEnemies;
        enemyVector.x = transform.position.x + Mathf.Cos(theta * numberSpawned) * radius;
        enemyVector.y = transform.position.y + Mathf.Sin(theta * numberSpawned) * radius;

        return enemyVector;
    }

}
