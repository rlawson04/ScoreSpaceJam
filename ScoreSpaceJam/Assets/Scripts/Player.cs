using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    private float health = 100;

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

    [SerializeField]
    private float projectileCooldown = .5f;

    [SerializeField]
    private TextMeshProUGUI deathText;

    [SerializeField]
    private GameObject deathButton;

    private float timer;

    Vector2 movement = new Vector2();

    // Properties
    public float Health
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
        timer = projectileCooldown;
        health = 100;
        healthbar.SetMaxHealth(health);
    }

    private void Update()
    {
        GetInput();

        timer -= Time.deltaTime;


        // Update health bar
        healthbar.SetHealth(health);

        // Shoots crown projectile
        if (Input.GetKeyDown(KeyCode.Space) && timer <= 0)
        {
            //Instantiate(projectile, transform.position, Quaternion.identity);
            ProjectileManager.instance.PlayerShootProjectile(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            timer = projectileCooldown;
            animator.SetTrigger("Attack");
        }

        // return to start button
        if (Input.GetKey(KeyCode.P))
        {
            transform.position = new Vector2(0f, 0f);
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
        health -= Time.deltaTime * 2;

        if (health <= 0)
        {
            Time.timeScale = 0;
            deathText.text = "You have died!";
            deathButton.SetActive(true);
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
