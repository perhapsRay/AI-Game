using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour {

    public GameObject small;
    public GameObject drone;
    public GameObject wing;
    public GameObject seeker;
    public GameObject boss;
    public GameObject point1;
    public GameObject point2;
    public GameObject point3;
    public GameObject point4;
    public GameObject cross;
    public GameObject player;
    float time;

    // Use this for initialization
    void Start () {
        Instantiate(player.GetComponent<Rigidbody2D>(), new Vector3(0, -6, 0), Quaternion.Euler(new Vector3(0, 0, 0)));

        InvokeRepeating("SpawnDrone", 0, 0.5f);
        InvokeRepeating("SpawnCross", 1, 5);
        InvokeRepeating("SpawnCross2", 1, 5);
        Invoke("SpawnPoints", 1);
        InvokeRepeating("SpawnSmall", 0, 0.5f);
        InvokeRepeating("SpawnWing", 1, 5);
        InvokeRepeating("SpawnSeeker", 1, 2);
        InvokeRepeating("SpawnBoss", 1, 5);

        //InvokeRepeating("SpawnSeeker", 0, 1f);
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        Debug.Log(time);

    }

    void SpawnPoints()
    {
        if (time > 1 && time < 4)
        {
            Instantiate(point1.GetComponent<Rigidbody2D>(), new Vector3(0, 16, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            Instantiate(point2.GetComponent<Rigidbody2D>(), new Vector3(0, 11, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            Instantiate(point3.GetComponent<Rigidbody2D>(), new Vector3(3, 8, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            Instantiate(point4.GetComponent<Rigidbody2D>(), new Vector3(-3, 8, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
    }

    void SpawnCross()
    {
        if (time > 15 && time < 17)
        {
            Instantiate(cross.GetComponent<Rigidbody2D>(), new Vector3(-5, 16, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
    }
    void SpawnCross2()
    {
        if (time > 20 && time < 22)
        {
            Instantiate(cross.GetComponent<Rigidbody2D>(), new Vector3(5, 16, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
    }

    void SpawnDrone()
    {

        if (time > 2 && time < 4 || time > 7 && time < 8 || time > 18 && time < 20 || time > 24 && time < 26)
        {
            Instantiate(drone.GetComponent<Rigidbody2D>(), new Vector3(-3, 16, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            Instantiate(drone.GetComponent<Rigidbody2D>(), new Vector3(3, 16, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            Instantiate(drone.GetComponent<Rigidbody2D>(), new Vector3(0, 14, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
        }  
    }

    void SpawnSmall()
    {
        if (time > 11 && time< 13 || time > 21 && time < 23)
        {
            Instantiate(small.GetComponent<Rigidbody2D>(), new Vector3(-3, 14, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            Instantiate(small.GetComponent<Rigidbody2D>(), new Vector3(3, 14, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
    }

    void SpawnWing()
    {
        if (time > 15 && time < 18)
        {
            Instantiate(wing.GetComponent<Rigidbody2D>(), new Vector3(-7, 14, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            Instantiate(wing.GetComponent<Rigidbody2D>(), new Vector3(-9, 12, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            Instantiate(wing.GetComponent<Rigidbody2D>(), new Vector3(-11, 10, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
    }

    void SpawnSeeker()
    {
        if (time > 20 && time < 24 || time > 30 && time < 34)
        {
            Instantiate(seeker.GetComponent<Rigidbody2D>(), new Vector3(16, 26, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            Instantiate(seeker.GetComponent<Rigidbody2D>(), new Vector3(-8, 20, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
    }

    void SpawnBoss()
    {
        if (time > 35 && time < 37)
        {
            Instantiate(boss.GetComponent<Rigidbody2D>(), new Vector3(0, 16, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
    }

    //void SpawnSeeker()
    //{
    //    if (time > 24 && time < 25)
    //    {
    //        Instantiate(seeker.GetComponent<Rigidbody2D>(), new Vector3(-10, 20, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
    //        Instantiate(seeker.GetComponent<Rigidbody2D>(), new Vector3(10, 30, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
    //        Instantiate(seeker.GetComponent<Rigidbody2D>(), new Vector3(0, 35, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
    //    }

    //    if (time > 26 && time < 28)
    //    {
    //        Instantiate(seeker.GetComponent<Rigidbody2D>(), new Vector3(-10, -5, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
    //        Instantiate(seeker.GetComponent<Rigidbody2D>(), new Vector3(20, 5, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
    //        Instantiate(seeker.GetComponent<Rigidbody2D>(), new Vector3(-20, 20, 0), Quaternion.Euler(new Vector3(0, 0, 0)));

    //    }
    //}

}
