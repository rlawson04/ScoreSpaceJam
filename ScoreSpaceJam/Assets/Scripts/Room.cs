using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    private bool hasEnemies;
    [SerializeField] private GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        hasEnemies = true;
        door.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.instance.transform.position.y > transform.position.y && hasEnemies)
        {
            door.SetActive(true);
        }
    }
}
