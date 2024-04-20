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
    private uint health = 10;

    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private Rigidbody2D rb2D;

    [SerializeField]
    private Animator animator;

    Vector2 movement = new Vector2();

    // Properties
    public uint Health
    {
        get { return health; }
        set { health = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
 
    }

    private void Update()
    {
        GetInput();

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
        }

        if (Input.GetKey(KeyCode.A))
        {
            animator.SetTrigger("walking");
            transform.localScale = new Vector3(-1.677228f, 1.677228f, 1.677228f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetTrigger("walking");
            transform.localScale = new Vector3(1.677228f, 1.677228f, 1.677228f);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            animator.SetTrigger("walking");
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetTrigger("walking");
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetTrigger("walking");
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //MoveCharacter(movement);
        rb2D.MovePosition(rb2D.position + movement * moveSpeed * Time.fixedDeltaTime);
        
    }

    void GetInput()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    public void MoveCharacter(Vector2 movementVector)
    {
        movementVector.Normalize();
        rb2D.velocity = movementVector * moveSpeed * Time.deltaTime;
        
    }
}
