using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour {

    public GameObject small;
    float time;

    // Use this for initialization
    void Start () {
        InvokeRepeating("SpawnEnemy", 1, 1.2f);
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
    }

    void SpawnEnemy()
    {

        if (time > 5 && time < 12 || time > 17 && time < 20)
        {
            Instantiate(small.GetComponent<Rigidbody2D>(), new Vector3(-2.5f, 16, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            Instantiate(small.GetComponent<Rigidbody2D>(), new Vector3(2.5f, 16, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        
    }
 
}
