using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDestroy : MonoBehaviour {

    private int health;
    public GameObject explosion;
    public Transform body;
    public AudioClip enemyexpl;
    public AudioSource MusicSource;

    // Use this for initialization
    void Start () {

        MusicSource.clip = enemyexpl;

        if (gameObject.tag == "drone")
        {
            health = 1;
        }
        if (gameObject.tag == "small")
        {
            health = 2;
        }
        if (gameObject.tag == "wing")
        {
            health = 2;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet (Clone)")
        {
            health--;
            Destroy(collision.gameObject);
            if (health <= 0)
            {
                Instantiate(explosion, body.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                score.scoreAmount += 10;
                MusicSource.Play();
                Destroy(gameObject);
            }
        }
    }
}
