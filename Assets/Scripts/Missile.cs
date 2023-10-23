using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public Transform target;
    public float speed = 70f;
    public int Damage = 1;
    public GameObject BulletImpact;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if(dir.magnitude <= 0.2f)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    public void Seek( Transform _target)
    {
        target = _target;
    }

    public void HitTarget()
    {
        GameObject effect =  Instantiate(BulletImpact,transform.position, transform.rotation);
        Destroy(effect, 3f);
        Destroy(gameObject);
        target.GetComponent<Enemy>().health -= Damage;
    }
}
