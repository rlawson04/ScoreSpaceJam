using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private EnemyManager enemyManager;

    // Start is called before the first frame update
    void Start()
    {
        door.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyManager.EnemyList.Count == 0) 
        {
            door.SetActive(false);
        }
        else
        {
            door.SetActive(true);
        }
    }
}
