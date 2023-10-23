using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
   public static int Money;
    public static int Lives;
    public int StartMoney = 300;
    public int StartLives= 20;
    public Text money;
    public Text lives;
    

    private void Start()
    {
        Money = StartMoney;
        Lives = StartLives;
    }

    private void Update()
    {
        money.text = Money.ToString();
        lives.text = Lives.ToString();
        if(Lives <= 0)
        {
            //Time.timeScale = 0;
            
        }
    }
}
