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
