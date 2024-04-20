using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;

    [SerializeField]
    private uint damage = 1;

    [SerializeField]
    private float range = 10f;

    [SerializeField]
    private Vector3 direction;

    [SerializeField]
    private bool friendly;

    [SerializeField]
    private float distanceTravelled = 0f;

    // Properties
    public Vector3 Direction
    {
        get { return direction; }
        set { direction = value; }
    }

    public float DistanceTravelled
    {
        get { return distanceTravelled; }
        set { distanceTravelled = value; }
    }

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public float Range
    {
        get { return range; }
        set { range = value; }
    }

    public uint Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    public bool Friendly
    {
        get { return friendly; }
        set { friendly = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        // ignore collision with player
        Physics2D.IgnoreCollision(Player.instance.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {/*
        if (distanceTravelled <= range)
        {
            transform.position += Vector3.ClampMagnitude(direction, 1f) * Time.deltaTime * speed;
            distanceTravelled += Time.deltaTime * speed;
        }*/
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            ProjectileManager.instance.Projectiles.Remove(this);
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            Debug.Log(collision.gameObject.name + " has been hit!");
        }
    }
}
