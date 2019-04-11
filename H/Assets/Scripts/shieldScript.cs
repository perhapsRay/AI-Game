using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldScript : MonoBehaviour {

    public static int shieldHP = 20;
    public GameObject explosion;
    public Transform body;

	// Use this for initialization
	void Start () {
        shieldHP = 20;
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet (Clone)")
        {
            shieldHP -= 1;
            Destroy(collision.gameObject);
            if (shieldHP <= 0)
            {
                Instantiate(explosion, body.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                angel.shieldHealth = false;
                Destroy(gameObject);
            }
        }
    }
}
