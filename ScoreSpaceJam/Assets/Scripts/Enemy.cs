using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EnemyManager.instance.MakeEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
