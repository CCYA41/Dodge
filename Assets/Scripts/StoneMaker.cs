using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StoneMaker : MonoBehaviour
{
    [Header("Status")]
    [SerializeField] GameObject Stone;

    [SerializeField] float targetStoneTimer;
    [SerializeField] float randomStoneTimer;
    [SerializeField] float stoneX;
    [SerializeField] float stoneY;
    [SerializeField] float randomStoneX;
    [SerializeField] float gameTime;
    //[SerializeField] float screenX;
    //[SerializeField] float screenY;


    private void Awake()
    {

        initailize();


    }
    void Update()
    {
        MakeStone();
    }
    private void MakeStone()
    {

        var player = GameObject.FindObjectOfType<PlayerCtrl>();
        gameTime += Time.deltaTime;
        targetStoneTimer += Time.deltaTime;
        randomStoneTimer += Time.deltaTime;

        if (randomStoneTimer > 0.2 && (player.userState != "DIE"))
        {
            stoneX = Random.Range(-7.25f, 7.25f);
            Instantiate(Stone, new Vector3(stoneX, 7.3f, 0), Quaternion.identity);
            randomStoneTimer = 0;
        }
        if (targetStoneTimer > 0.5 && player.userState == "IDLE" && player.tag == "Player")
        {
            if (player.transform.position.x > 0)
            {
                Instantiate(Stone, new Vector3(player.transform.position.x - 1, 7.3f, 0), Quaternion.identity);

                targetStoneTimer = 0;
            }
            else
            {
                Instantiate(Stone, new Vector3(player.transform.position.x + 1, 7.3f, 0), Quaternion.identity);

                targetStoneTimer = 0;
            }
        }
    }
    public void initailize()
    {

        targetStoneTimer = 0;
        stoneX = 0f;
        //stoneY = 0f;
        //screenX = Screen.width;
        //screenY = Screen.height;
    }
}
