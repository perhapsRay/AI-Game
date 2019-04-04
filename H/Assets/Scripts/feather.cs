using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feather : MonoBehaviour {

    public float speed = 10f;
    private int health;
    public GameObject explosion;
    public Transform body;

    GameObject target;
    Vector2 moveDirection;


	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player");
        moveDirection = (target.transform.position - transform.position).normalized;


        if (gameObject.tag == "seeker")
        {
            health = 2;
        }

        if (gameObject.tag == "feather")
        {
            health = 99999;
        }

        if (gameObject.tag == "boss striker")
        {
            health = 20;
        }
    }
	
	// Update is called once per frame
	void Update () {
        //transform.Translate(Vector3.down * Time.deltaTime * speed);
        
        
        transform.position += new Vector3(moveDirection.x, moveDirection.y, 0) * speed * Time.deltaTime;
        transform.up = -moveDirection;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet (Clone)")
        {
            health--;
            Destroy(collision.gameObject);
            if (health <= 0)
            {
                if(gameObject.tag == "seeker")
                {
                    Instantiate(explosion, body.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                }
                Destroy(gameObject);

            }
        }
    }
}
