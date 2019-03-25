using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour {

    public GameObject small;

    // Use this for initialization
    void Start () {
        InvokeRepeating("SpawnEnemy", 1, 2.8f);
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    void SpawnEnemy()
    {
        Instantiate(small.GetComponent<Rigidbody2D>(), new Vector3(-2.5f, 16,0), Quaternion.Euler(new Vector3(0, 0, 0)));
        Instantiate(small.GetComponent<Rigidbody2D>(), new Vector3(2.5f, 16, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
    }
}
