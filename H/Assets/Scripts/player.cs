using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    float speed = 8;
    public GameObject bullet;
    float bulletSpeed = 15;
    public float timer = 0;

    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        //Movement
        if((Input.GetKey("left"))&& transform.position.x > -5.62)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if ((Input.GetKey("right"))&& transform.position.x < 5.6)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        if ((Input.GetKey("up")) && transform.position.y < 7.6)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }

        if ((Input.GetKey("down")) && transform.position.y > -7.8)
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
        //Shooting
        if (Input.GetKey(KeyCode.Space))
        {
            timer -= Time.deltaTime; // Time between create a bullet and the next bullet

            if (timer <= 0)
            {
                Rigidbody2D bulletInstance;
                bulletInstance = Instantiate(bullet.GetComponent<Rigidbody2D>(), transform.position, Quaternion.Euler(new Vector3(0, 0, 1)));
                bulletInstance.name = "Bullet(Clone)";
                bulletInstance.velocity = transform.up * bulletSpeed;
                timer = 0.15f;
            }
        }
    }

   
}
