using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_PlayerMovement : MonoBehaviour
{

    public int hp;

    private Vector3 mousePosition;
    private Vector3 direction;
    private Rigidbody2D rb;
    public float moveSpeed = 30f;
    public GameObject mainCamera;

    public scr_WeaponSystem[] WeaponSystems;
    private int currentWeaponSystemIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        //rb.AddRelativeForce(new Vector2(-moveSpeed, 0), ForceMode2D.Impulse);
        //Dummheit lol
    }

    // Update is called once per frame
    void Update()
    {
        //Fire
        if (Input.GetAxisRaw("Fire1") != 0) WeaponSystems[currentWeaponSystemIndex].Fire();

        mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, -10);

        //MoveTowardsCursor
        
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        direction = mousePosition - transform.position;
        direction.Normalize();

        //transform.position = Vector2.LerpUnclamped(transform.position, mousePosition, moveSpeed);
        //Dummheit lol

        //Rotate to Cursor
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        if(hp <= 0)
        {
            StartCoroutine(GameOver());
        }
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    private void FixedUpdate()
    {
        MovePlayer(direction);
    }

    void MovePlayer(Vector2 direction)
    {
        Debug.Log(direction.magnitude);
        float x = direction.magnitude / 0.3f;
        //0,2 = direction.magnitude /x
        direction = direction / x;
        rb.MovePosition((Vector2) transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    IEnumerator GameOver()
    {
        Debug.Log("Dead");
        yield return new WaitForSeconds(0.1f);
    }

}
