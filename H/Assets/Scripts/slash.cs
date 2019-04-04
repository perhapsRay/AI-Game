using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slash : MonoBehaviour {

    public float speed = 8f;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet (Clone)")
        {
            Destroy(collision.gameObject);
        }
    }
}
