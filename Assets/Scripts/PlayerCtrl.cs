using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{

    public enum STATE
    {
        IDLE = 0,
        LEFT,
        RIGHT,
        DIE
    }

    [Header("Status")]
    [SerializeField] public float gameTime;
    [SerializeField] float speed;
    //[SerializeField] string curState;
    [SerializeField] float timer;
    [SerializeField] STATE state;

    public string userState;
    Vector3 startPosition;

    Rigidbody2D rigi2D;
    //CapsuleCollider2D capCol2D;
    Animator anim;

    private void Awake()
    {
        PlayerInitialize();
    }

    private void Update()
    {

        PlayerControl();

    }
    public void PlayerInitialize()
    {
        GameObject.FindObjectOfType<GameManager>().isDead = false;
        
        state = STATE.IDLE;
        userState = state.ToString();
        //Debug.Log("루프작동!");
        startPosition = this.transform.position;

        this.gameObject.tag = "Untagged";
        this.gameObject.layer = 0;

        rigi2D = this.GetComponent<Rigidbody2D>();
        //capCol2D = this.GetComponent<CapsuleCollider2D>();
        anim = this.GetComponent<Animator>();

        rigi2D.gravityScale = 1;
        rigi2D.constraints = RigidbodyConstraints2D.FreezeRotation;

        //capCol2D.enabled = true;

        //curState = "Idle";
        speed = 7f;
        timer = 0f;
        //Debug.Log("루프작동!!");
    }
    private void PlayerControl()
    {
      //  gameTime += Time.deltaTime;

        if (state == STATE.DIE)
        {


            this.gameObject.tag = "Untagged";

            userState = state.ToString();

            this.gameObject.layer = 6;
            //capCol2D.enabled = false;
            //rigi2D.gravityScale = 0;

            timer += Time.deltaTime;
            if (timer > 2)
            {

                //this.gameObject.SetActive(false);
                this.transform.position = startPosition;
                GameObject.FindObjectOfType<GameManager>().isDead = true;
                state = STATE.IDLE;
            }

        }
        
        if(this.gameObject.tag == "Player")
        {
            if (Input.GetKey("left"))
            {
                //curState = "Left";
                state = STATE.LEFT;

                rigi2D.velocity = new Vector3(-speed, 0, 0);

              //  gameTime = 0;

            }
            if (Input.GetKey("right"))
            {
                //curState = "Right";
                state = STATE.RIGHT;

                rigi2D.velocity = new Vector3(speed, 0, 0);

              //  gameTime = 0;

            }
            if (rigi2D.velocity.x == 0 && state != STATE.DIE) //curState != "Boom")
            {//curState = "Idle";
                state = STATE.IDLE;
                
            }
        }

        anim.Play(state.ToString());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Stone"))
            //curState = "Boom";
            state = STATE.DIE;
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            this.gameObject.tag = "Player";
        }
    }

}
