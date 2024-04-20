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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (distanceTravelled <= range)
        {
            transform.position += Vector3.ClampMagnitude(direction, 1f) * Time.deltaTime * speed;
            distanceTravelled += Time.deltaTime * speed;
        }
    }
}
