using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Enemy_Circler : MonoBehaviour
{
    Vector3 direction;

    public scr_WeaponSystem WeaponSystem;

    private bool arrived = false;
    public float AngularSpeed, RotationRadius;
    private float posX, posY, RotationAngle;

    GameObject[] EnemyGameObjects;
    Transform[] Enemies;

    //public Transform moveTowards;
    //Vector3 moveTowardsDirection;

    public Transform player;
    Rigidbody2D rb;
    public float maxDistance = 15f;
    public float moveSpeed = 10f;
    public float repelRange = 10f;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = this.GetComponent<Rigidbody2D>();
        AssociateEnemyArray();
    }

    // Update is called once per frame
    void Update()
    {
        direction = player.transform.position - transform.position;
        //moveTowardsDirection = transform.position - moveTowards.position;
        //Debug.Log(moveTowardsDirection);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
    }

    private void FixedUpdate()
    {
        AssociateEnemyArray();

        Vector2 repelForce = Vector2.zero;
        MoveEnemy(direction);


        foreach (Transform enemy in Enemies)
        {
            if (enemy != null)
            {
                if (Vector2.Distance(enemy.position, rb.position) <= repelRange)
                {
                    repelForce += (rb.position - (Vector2)enemy.position).normalized;
                }
            }

            Vector2 newPos = (Vector2)transform.position + Vector2.zero;
            if (Vector2.Distance(transform.position, player.transform.position) >= maxDistance)
            {
                newPos = transform.position + (direction * moveSpeed * Time.deltaTime);
            }
            newPos += repelForce * Time.deltaTime;
            rb.MovePosition(newPos);

        }



    }

    void MoveEnemy(Vector2 direction)
    {
        //Debug.Log(Vector2.Distance(transform.position, player.transform.position));
        if (Vector2.Distance(transform.position, player.transform.position) <= maxDistance && arrived == false)
        {
            rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
            arrived = true;
        }

        if(arrived == true)
        {
            posX = player.position.x + Mathf.Sin(RotationAngle) * RotationRadius;
            posY = player.position.y + Mathf.Cos(RotationAngle) * RotationRadius;
            transform.position = new Vector3(posX, posY, 0);
            RotationAngle = RotationAngle + Time.deltaTime * AngularSpeed;
            WeaponSystem.Fire();
            if (RotationAngle >= 360) RotationAngle = 0;

        }

    }

    void AssociateEnemyArray()
    {
        int x = 0;
        EnemyGameObjects = new GameObject[GameObject.FindGameObjectsWithTag("Enemy").Length];
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            EnemyGameObjects[x] = enemy;
            x++;
        }
        Enemies = new Transform[EnemyGameObjects.Length];
        for (int i = 0; i < EnemyGameObjects.Length; i++)
        {
            Enemies[i] = EnemyGameObjects[i].GetComponent<Transform>();
            //Debug.Log(Enemies[i]);
        }
    }

}
