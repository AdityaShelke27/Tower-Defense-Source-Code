using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
   
    [HideInInspector]
    public float speed;
    private Transform target;
    public int waypointIndex = 0;
    public float health = 5; 
    void Awake()
    {
        GetComponent<MeshRenderer>().material.color = new Color(Random.value, Random.value, Random.value);
    }
    // Start is called before the first frame update
    void Start()
    {
        speed = startSpeed;
        target = WayPoints.points[waypointIndex];
    }

    // Update is called once per frame
    void Update()
    {
       
        if(health <= 0)
        {
            Destroy(gameObject);
            PlayerStats.Money += 20;
        }
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if(Vector3.Distance(transform.position, target.position) <= 0.2)
        {
            if(waypointIndex >= WayPoints.points.Length - 1)
            {
                PlayerStats.Lives--;
                Destroy(gameObject);
                return;
            }
            waypointIndex++;
            target = WayPoints.points[waypointIndex];
        }

        speed = startSpeed;
    }

    public void Slow(float pct)
    {
       
        speed = startSpeed * pct;
        
    }
    
}
