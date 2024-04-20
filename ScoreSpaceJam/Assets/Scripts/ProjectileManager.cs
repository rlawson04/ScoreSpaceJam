using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public static ProjectileManager instance;

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

    [SerializeField]
    private List<Projectile> projectiles = new List<Projectile>();

    [SerializeField]
    private GameObject projectilePrefab;

    public List<Projectile> Projectiles
    {
        get { return projectiles; }
        set { projectiles = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move all projectiles
        for (int i = 0; i < projectiles.Count; i++)
        {
            if (projectiles[i].DistanceTravelled <= projectiles[i].Range)
            {
                projectiles[i].transform.position += projectiles[i].Direction.normalized * Time.deltaTime * projectiles[i].Speed;
                projectiles[i].DistanceTravelled += Time.deltaTime * projectiles[i].Speed;
            }
            else // destroy projectile if out of range
            {
                Destroy(projectiles[i].gameObject);
                projectiles.RemoveAt(i);
                i--;
            }
            /*
            // collision with enemies
            if (projectiles[i].Friendly)
            {
                for (int j = 0; j < EnemyManager.instance.EnemyList.Count; j++)
                {
                }
            }
            */
        }   
    }

    public void PlayerShootProjectile(Vector3 playerPosition, Vector3 mousePosition)
    {
        Vector3 direction = mousePosition - playerPosition;
        direction.z = 0;
        //Debug.Log(direction);
        //Debug.Log(direction.normalized);
        GameObject proj = Instantiate(projectilePrefab, playerPosition, Quaternion.identity); //.GetComponent<Projectile>().Direction = direction.normalized;
        // TODO: rewrite this to not use GetComponent
        Projectile projGet = proj.GetComponent<Projectile>();
        projGet.Direction = direction.normalized;
        projGet.Friendly = true;
        //proj.layer = 6; // sets the projectile layer to "Enemy"
        projectiles.Add(proj.GetComponent<Projectile>());
    }
}
