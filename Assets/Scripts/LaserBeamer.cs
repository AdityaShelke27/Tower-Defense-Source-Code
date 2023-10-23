using UnityEngine;

public class LaserBeamer : MonoBehaviour
{
    private Enemy targetEnemy;
    public GameObject enemy;
    public Transform bulletSpawner;
    public float SlowAmount = 0.7f;
    public float range = 15f;
    public string Theenemies = "Enemy";
    public Transform barrel;
    public float DamagePerSec = 3f;
    public ParticleSystem laserParticle;
    public Light impactLight;
    public float ParticleRate = 0f;
    public bool useLaser = false;
    public LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        impactLight.enabled = false;
        InvokeRepeating("UpdateTarget", 0, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy == null)
        {
            useLaser = false;
            if(lineRenderer.enabled)
            {
                lineRenderer.enabled = false;
                laserParticle.Stop();
                impactLight.enabled = false;
            }
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
            enemy = nearestEnemy;
            useLaser = true;
            lineRenderer.enabled = true;
            targetEnemy = enemy.GetComponent<Enemy>();
        }
        else
        {
            enemy = null;
            targetEnemy = null;
        }
        
    }
    void Fire()
    {
        Vector3 Rotation = Quaternion.Lerp(barrel.rotation, Quaternion.LookRotation(enemy.transform.position - barrel.position), Time.deltaTime * 4) .eulerAngles;
        barrel.rotation = Quaternion.Euler(0,Rotation.y,0);

        Laser();
    }

    void Laser()
    {
        targetEnemy.health -= DamagePerSec * Time.deltaTime;
        if(ParticleRate <= 0.05f)
        {
            laserParticle.Play();
            ParticleRate = 1f;
        }
        targetEnemy.Slow(SlowAmount);
        impactLight.enabled = true;
        ParticleRate -= Time.deltaTime;
        lineRenderer.SetPosition(0, bulletSpawner.position);
        lineRenderer.SetPosition(1, enemy.transform.position);
        Vector3 dir = transform.position - enemy.transform.position;
        laserParticle.transform.rotation = Quaternion.LookRotation(dir);
        laserParticle.transform.position = enemy.transform.position + dir.normalized;
        
    }
}
