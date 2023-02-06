using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropStone : MonoBehaviour
{
    [Header("Status")]
    [SerializeField] private float dropSpeed;

    Rigidbody2D rigi2D;

    private void Awake()
    {

        Initialize();
    }
    private void Update() 
    {
        CheckDie();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(this.gameObject);
        }
    }

    public void Initialize()
    {
        dropSpeed = Random.Range(1f, 3f);

        rigi2D = GetComponent<Rigidbody2D>();
        rigi2D.gravityScale = dropSpeed;
    }

    public void CheckDie()
    {
        if (FindObjectOfType<GameManager>().isDead == true)
        {
            Destroy(this.gameObject);
        }
    }
}
