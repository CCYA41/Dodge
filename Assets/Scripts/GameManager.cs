using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    //public static GameManager instance;
    public GameObject gameStart;
    public GameObject GameOver;
    public GameObject Restart;
    public GameObject Player;

    public bool isStart = false;
    public bool isDead;




    private void Awake()
    {
        Initialize();

        //if (instance == null)
        //    instance = this;
        //else
        //    Destroy(this.gameObject);


    }
    private void Update()
    {
        PlayerDead();
    }
    public void Initialize()
    {
        if (!isStart)
        {
            gameStart.SetActive(true);
            isDead = false;
            isStart = true;
            Player.SetActive(true);
            GameOver.SetActive(false);
            Restart.SetActive(false);
            Time.timeScale = 0;
            
        }
        else
        {
            isDead = false;
            gameStart.SetActive(false);
            Player.SetActive(true);
            GameOver.SetActive(false);
            Restart.SetActive(false);
            Time.timeScale = 1;
        }
        



    }
    public void PlayerDead()
    {
        
        if (isDead)
        {
            GameOver.SetActive(true);
            Restart.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
