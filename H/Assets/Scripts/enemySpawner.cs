using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour {

    public GameObject small;
    public GameObject drone;
    public GameObject seeker;
    public GameObject player;
    float time;

    // Use this for initialization
    void Start () {
        Instantiate(player.GetComponent<Rigidbody2D>(), new Vector3(0f, -6, 0), Quaternion.Euler(new Vector3(0, 0, 0)));

        InvokeRepeating("SpawnDrone", 0, 0.8f);
        InvokeRepeating("SpawnSmall", 1, 0.6f);
        InvokeRepeating("SpawnSeeker", 1, 1f);
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
    }

    void SpawnDrone()
    {

        if (time > 1 && time < 4 || time > 7 && time < 10)
        {
            Instantiate(drone.GetComponent<Rigidbody2D>(), new Vector3(-3f, 18, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            Instantiate(drone.GetComponent<Rigidbody2D>(), new Vector3(3f, 18, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            Instantiate(drone.GetComponent<Rigidbody2D>(), new Vector3(0f, 16, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
        }  
    }

    void SpawnSmall()
    {
        if (time > 15 && time< 18)
        {
            Instantiate(small.GetComponent<Rigidbody2D>(), new Vector3(-3f, 18, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            Instantiate(small.GetComponent<Rigidbody2D>(), new Vector3(3f, 18, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
    }

    void SpawnSeeker()
    {
        if (time > 24 && time < 25)
        {
            Instantiate(seeker.GetComponent<Rigidbody2D>(), new Vector3(-10f, 20, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            Instantiate(seeker.GetComponent<Rigidbody2D>(), new Vector3(10f, 30, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
    }

}
