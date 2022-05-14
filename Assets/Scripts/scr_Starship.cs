using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Starship : MonoBehaviour
{
    public float speed = 10;
    public GameObject cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = new Vector3(transform.position.x, transform.position.y, -10);

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            gameObject.transform.position += new Vector3(0, 1, 0) * speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetAxisRaw("Vertical") < 0)
        {
            gameObject.transform.position += new Vector3(0, -1, 0) * speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            gameObject.transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            gameObject.transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
    }
}
