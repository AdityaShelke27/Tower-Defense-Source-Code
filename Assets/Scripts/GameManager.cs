using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject Select;
    public GameObject gameover;
    public GameObject shop;
    // Start is called before the first frame update
    void Start()
    {
        Select.SetActive(false);
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerStats.Lives <= 0 )
        {
            gameOver = true;
        }

        if(gameOver)
        {
            gameover.SetActive(true);
            shop.SetActive(false);
        }
    }

    public void SelectTurret()
    {
        Select.SetActive(true);
    }

    public void Deselect()
    {
        Select.SetActive(false);
    }
}
