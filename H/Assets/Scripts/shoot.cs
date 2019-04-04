using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {

    public GameObject feather;
    public Transform body; 

    // Use this for initialization
    void Start () {

        if (gameObject.tag == "small")
        {
            InvokeRepeating("Shoot", 1f, 1f);
        }
        if (gameObject.tag == "wing")
        {
            InvokeRepeating("Shoot", 0f, 0.2f);
        }

        if (gameObject.tag == "boss striker")
        {
            InvokeRepeating("Shoot", 0f, 0.2f);
        }
    }
	
	// Update is called once per frame
	void Update () {

    }

    void Shoot()
    {
        int shootchance = Random.Range(0, 100);

        if (shootchance > 85)
        {
            Instantiate(feather, body.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        }
    }

}
