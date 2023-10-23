using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text waves;
    public GameObject enemyWaves;
    private void OnEnable()
    {
        waves.text = enemyWaves.GetComponent<EnemySpawner>().waveNumber.ToString(); 
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
       
    }

    public void Quit()
    {

    }
}
