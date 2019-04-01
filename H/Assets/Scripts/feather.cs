using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feather : MonoBehaviour {

    public float speed = 10f;
    Rigidbody2D rb;

    player target;
    Vector2 moveDirection;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<player>();
        moveDirection = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
    }
	
	// Update is called once per frame
	void Update () {
        //transform.Translate(Vector3.down * Time.deltaTime * speed);

    }
}
