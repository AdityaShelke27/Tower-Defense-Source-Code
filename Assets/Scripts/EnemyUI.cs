using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    public GameObject enemy;
    public Slider health;
    //public Transform cam;
    //public Transform canvas;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Slider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        health.value = (enemy.GetComponentInParent<Enemy>().health / 5);
        
        //Debug.Log(canvas.transform.rotation);
    }

    /*private void LateUpdate()
    {
        canvas.LookAt(canvas.position + cam.forward);
    }
    */
}
