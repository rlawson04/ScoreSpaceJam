using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] uint health;
    float speed;
    uint damage;
    float range;

    // Start is called before the first frame update
    void Start()
    {
        health = 10;
        speed = 1;
        damage = 2;
        range = 10;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(Player.instance.transform.position, transform.position);

        if (distance < range)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.instance.transform.position, speed * Time.deltaTime);
        }

        if(health <= 0 )
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(uint damage)
    {
        health -= damage;
        Debug.Log("Took Damage");
    }
}
