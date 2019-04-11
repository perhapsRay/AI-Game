﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthbar : MonoBehaviour {

    public Transform bar;

	// Use this for initialization
	private void Start ()
    {
        bar = transform.Find("Bar");
	}

    public void SetSize(float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }
	
}
