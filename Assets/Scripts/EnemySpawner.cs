using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public int waveNumber = 0;
    [SerializeField]
    private Transform enemy;
    public float countDown = 2f;
    public Text waveCountDown, wavenum;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(countDown <= 0)
        {
            StartCoroutine(SpawnWave());          
            countDown = waveNumber * 3f;
            
        }
        countDown -= Time.deltaTime;
        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);
        waveCountDown.text = string.Format("{0:00.00}", countDown);
        wavenum.text = waveNumber.ToString();
    }
    IEnumerator SpawnWave()
    {
        waveNumber++;
            for (int m = 0; m < waveNumber; m++)
            {
                Instantiate(enemy, new Vector3(4.96f, 1.73f, 8.88f), Quaternion.identity);
            yield return new WaitForSeconds(0.4f);
            }
        
    }
}
