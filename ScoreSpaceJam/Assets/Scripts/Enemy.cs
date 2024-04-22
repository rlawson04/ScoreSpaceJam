using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] private healthbar healthbar;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject bloodpuddle;

    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask playerLayers;
    private int attackDamage;

    [SerializeField] private float attackRate;
    float nextAttackTime;

    float speed;
    float detectionRange;
    
    // Start is called before the first frame update
    void Start()
    {
        health = 10;
        speed = Random.Range(2, 4);
        detectionRange = 10;
        attackRange = 0.5f;
        attackDamage = 5;
        attackRate = 2f;
        nextAttackTime = 0f;
        healthbar.SetMaxHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        // Making enemy face player
        if (Player.instance.transform.position.x > transform.position.x) 
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        // Distance between player and enemy
        float distance = Vector2.Distance(Player.instance.transform.position, transform.position);

        // Sets the health bar to the enemy's current health
        healthbar.SetHealth(health);

        // Moves towards player if player is within enemy detection range
        if (distance < detectionRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.instance.transform.position, speed * Time.deltaTime);
        }

        // Attacks the player when withing a short range
        if (distance < attackRange)
        {
            if (Time.time >= nextAttackTime)
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
                
            }
        }

        // When the enemy dies, the object is destroyed and the player is slightly healed
        if (health <= 0)
        {
            Instantiate(bloodpuddle, transform.position, Quaternion.identity);
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

    public void TakeDamage(int damage)
    {
        // Decrease health when hit by player
        health -= damage;

        transform.position += new Vector3(1, 0) * transform.localScale.x;
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

            //player gets knocked back
            Player.instance.transform.position -= new Vector3(1, 0) * transform.localScale.x;
        }
    }
}
