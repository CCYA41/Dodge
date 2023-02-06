using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMaker : MonoBehaviour
{
    [Header("Status")]
    [SerializeField] GameObject Stone;

    [SerializeField] float stoneTimer;
    [SerializeField] float stoneX;
    [SerializeField] float stoneY;
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
        stoneTimer += Time.deltaTime;

        if (stoneTimer > 0.2f && (player.userState != "DIE"))
        {
            stoneX = Random.Range(-7.25f, 7.25f);
            Instantiate(Stone, new Vector3(stoneX, 7.3f, 0), Quaternion.identity);
            stoneTimer = 0;
        }
        if (player.gameTime > 3 && player.userState == "IDLE")
        {
            if (player.transform.position.x > 0)
            {
                Instantiate(Stone, new Vector3(player.transform.position.x - 1, 7.3f, 0), Quaternion.identity);

                player.gameTime = 0;
            }
            else
            {
                Instantiate(Stone, new Vector3(player.transform.position.x + 1, 7.3f, 0), Quaternion.identity);

                player.gameTime = 0;
            }
        }
    }
    public void initailize()
    {

        stoneTimer = 0;
        stoneX = 0f;
        //stoneY = 0f;
        //screenX = Screen.width;
        //screenY = Screen.height;
    }
}
