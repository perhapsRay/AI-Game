using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthHandler : MonoBehaviour {

    public healthbar healthBar;
    //public GameObject Angel;

	// Use this for initialization
	void Start ()
    {
        healthBar.SetSize(angel.bosshealth);
        //Angel = GameObject.FindGameObjectWithTag("boss");
    }
	
	// Update is called once per frame
	void Update ()
    {
        //angel script = Angel.GetComponent<angel>();
        healthBar.SetSize(angel.bosshealth);
	}
}
