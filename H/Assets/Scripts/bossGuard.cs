using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossGuard : MonoBehaviour {

    public int health = 20;

    GameObject target;
    Vector2 moveDirection;

    // Use this for initialization
    void Start()
    {
        health = 20;
    }

    // Update is called once per frame
    void Update()
    {
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
                Destroy(gameObject);
            }
        }
    }
}