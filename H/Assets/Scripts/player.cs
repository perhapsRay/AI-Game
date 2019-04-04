using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    float speed = 8;
    public GameObject bullet;
    float bulletSpeed = 15;
    public float timer = 0;
    public static int health;

    public AudioClip shoot;
    public AudioSource MusicSource;

    // Use this for initialization
    void Start ()
    {
        MusicSource.clip = shoot;
        health = 3;
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

        if ((Input.GetKey("up")) && transform.position.y < 12.65)
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
                MusicSource.Play();
                if (score.scoreAmount > 100)
                {
                    timer = 0.10f;
                }
                else
                {
                    timer = 0.15f;
                }
            }
        }

        if (score.scoreAmount > 500)
        {
            speed = 10;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "feather" || collision.gameObject.tag == "drone" || collision.gameObject.tag == "seeker"
             || collision.gameObject.tag == "small" || collision.gameObject.tag == "slash" || collision.gameObject.tag == "wing"
             || collision.gameObject.tag == "boss" || collision.gameObject.tag == "boss striker")
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
