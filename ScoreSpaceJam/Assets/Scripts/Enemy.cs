using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] uint health;
    [SerializeField] private Animator animator;

    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask playerLayers;
    private uint attackDamage;

    [SerializeField] private float attackRate;
    float nextAttackTime;

    float speed;
    uint damage;
    float detectionRange;
    
    // Start is called before the first frame update
    void Start()
    {
        health = 10;
        speed = 1;
        damage = 2;
        detectionRange = 10;
        attackRange = 0.25f;
        attackDamage = 5;
        attackRate = 2f;
        nextAttackTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(Player.instance.transform.position, transform.position);

        // Moves towards player if player is within enemy detection range
        if (distance < detectionRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.instance.transform.position, speed * Time.deltaTime);
        }

        if (distance < attackRange)
        {
            if (Time.time >= nextAttackTime)
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
                
            }
        }

        if (health <= 0)
        {
            Destroy(gameObject);

            // Regenerate player health capped at 100
            if (Player.instance.Health < 100)
            {
                if (Player.instance.Health + 5 >= 100)
                {
                    Player.instance.Health = 100;
                }
                else
                {
                    Player.instance.Health += 5;
                }
            }
        }
    }

    public void TakeDamage(uint damage)
    {
        // Decrease health when hit by player
        health -= damage;
    }

    public void Attack()
    {
        // Play animation
        animator.SetTrigger("Attack");

        // Detect Enemies in range
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(transform.position, attackRange, playerLayers);

        // Apply damage
        foreach (Collider2D enemy in hitPlayer)
        {
            Player.instance.TakeDamage(attackDamage);
        }
    }
}
