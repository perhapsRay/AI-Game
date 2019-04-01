using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feather : MonoBehaviour {

    public float speed = 10f;


    GameObject target;
    Vector2 moveDirection;


	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player");
        moveDirection = (target.transform.position - transform.position).normalized;
    }
	
	// Update is called once per frame
	void Update () {
        //transform.Translate(Vector3.down * Time.deltaTime * speed);
        
        
        transform.position += new Vector3(moveDirection.x, moveDirection.y, 0) * speed * Time.deltaTime;
        transform.up = -moveDirection;
    }
}
