using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {

    public static int scoreAmount;
    public Text scoreText;

	// Use this for initialization
	void Start () {
        scoreText = GetComponent<Text>();
        scoreAmount = 0;
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score: " + scoreAmount;
	}
}
