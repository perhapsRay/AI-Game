using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthControl : MonoBehaviour {

    public GameObject heart1, heart2, heart3;

	// Use this for initialization
	void Start () {
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {

        if(player.health == 2)
        {
            heart1.gameObject.SetActive(false);
            heart2.gameObject.SetActive(true);
            heart3.gameObject.SetActive(true);
        }
        else if(player.health == 1)
        {
            heart1.gameObject.SetActive(false);
            heart2.gameObject.SetActive(false);
            heart3.gameObject.SetActive(true);
        }
        else if(player.health == 0)
        {
            heart1.gameObject.SetActive(false);
            heart2.gameObject.SetActive(false);
            heart3.gameObject.SetActive(false);
        }



	}
}
