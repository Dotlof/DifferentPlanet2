using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public int damage;
    public bool isEnemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy" && isEnemy == false)
        {
            collision.GetComponent<scr_EnemyHandling>().hp -= damage;
        }
        if (collision.tag == "Player" && isEnemy == true)
        {
            collision.GetComponent<scr_PlayerMovement>().hp -= damage;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.AddRelativeForce(new Vector2(-speed, 0), ForceMode2D.Impulse);
        Destroy(gameObject, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
