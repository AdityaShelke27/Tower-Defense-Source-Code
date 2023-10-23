using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform enemy, bulletSpawner;
    public float range = 15f;
    public string Theenemies = "Enemy";
    public Transform barrel;
    public GameObject bullet;
    public float fireRate = 1f;
    public float fireCountDown = 0;
    // Start is called before the first frame update
    void Start()
    {
        barrel = transform.GetChild(0);
        InvokeRepeating("UpdateTarget", 0, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy == null)
        {
            return;
        }
        else
        {
            Fire();
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(Theenemies);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach(GameObject a in enemies)
        {
            float distanceToEnemy = Vector3.Distance(a.transform.position, transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = a;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            enemy = nearestEnemy.transform;
        }
        else
        {
            enemy = null;
        }
    }
    void Fire()
    {
        Vector3 Rotation = Quaternion.Lerp(barrel.rotation, Quaternion.LookRotation(enemy.transform.position - barrel.position), Time.deltaTime * 4) .eulerAngles;
        barrel.rotation = Quaternion.Euler(0,Rotation.y,0);
        
        if(fireCountDown <= 0)
        {
            GameObject BulletGO = (GameObject) Instantiate(bullet, bulletSpawner.position, bulletSpawner.rotation);
            Bullet _bullet = BulletGO.GetComponent<Bullet>();
            if(_bullet != null)
            {
                _bullet.Seek(enemy);
            }
            fireCountDown = 1 / fireRate;
        }
        fireCountDown -= Time.deltaTime;
    }
}
