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
    List<Enemy> enemyList = new List<Enemy>();

    // Property
    public List<Enemy> EnemyList
    {
        get { return enemyList; }
        set { enemyList = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeEnemy()
    {
        Enemy enemy = new Enemy();

        enemyList.Add(enemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        Destroy(enemy);
        enemyList.Remove(enemy);
    }
}
