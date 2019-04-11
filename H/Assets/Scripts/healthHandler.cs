using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthHandler : MonoBehaviour {

    public healthbar healthBar;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        healthBar.SetSize(angel.bosshealth);
	}
}
