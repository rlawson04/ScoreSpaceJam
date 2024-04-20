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
    private float moveSpeed = 5f;

    [SerializeField]
    private uint health = 10;

    [SerializeField]
    private GameObject projectile;

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

    // Update is called once per frame
    void Update()
    {
        // movement
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);

        transform.position += movement * Time.deltaTime * moveSpeed;

        // combat
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pew pew");
            GameObject newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
            //newProjectile.Direction
        }
    }
}
