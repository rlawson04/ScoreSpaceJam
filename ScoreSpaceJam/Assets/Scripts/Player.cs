using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

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

    // Feilds
    [SerializeField]
    private float moveSpeed = 10f;

    [SerializeField]
    private int health = 100;

    [SerializeField]
    private int attackDamage = 5;

    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private Rigidbody2D rb2D;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private healthbar healthbar;

    Vector2 movement = new Vector2();

    // Properties
    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    public int AttackDamage
    {
        get { return attackDamage; }
        set { attackDamage = value; }
    }

    private void Start()
    {
        health = 100;
        healthbar.SetMaxHealth(health);
    }

    private void Update()
    {
        GetInput();

        // Update health bar
        healthbar.SetHealth(health);

        // Shoots crown projectile
        if (Input.GetMouseButtonDown(0))
        {
            //Instantiate(projectile, transform.position, Quaternion.identity);
            //ProjectileManager.instance.PlayerShootProjectile(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }

        // Animation handlers for each direction
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetTrigger("walking");
            transform.localScale = new Vector3(-1.677228f, 1.677228f, 1.677228f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetTrigger("walking");
            transform.localScale = new Vector3(1.677228f, 1.677228f, 1.677228f);
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            animator.SetTrigger("walking");
        }
        else
        {
            animator.SetTrigger("standing");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Handles player movement
        rb2D.MovePosition(rb2D.position + movement * moveSpeed * Time.fixedDeltaTime);
        
    }

    void GetInput()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    public void TakeDamage(int attackDamage)
    {
        // takes damage when hit
        health -= attackDamage;
        
    }
}
