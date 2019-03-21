using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlData
{
    public float moveX;
    public float moveY;
}
public class RepeatControlData
{
    public float moveX;
    public float moveY;
    public int repeat;
}
public class movePattern : MonoBehaviour {

    private RepeatControlData[] pattern;
    private int patternIndex = 0;
    private int repeatIndex = 0;
    public float horizontalSpeed = 1;
    public float verticalSpeed = 2;

    // Use this for initialization
    void Start () {
        // Create some control data
        RepeatControlData pdr = new RepeatControlData();
        pdr.moveX = 1.5f;
        pdr.repeat = 50;

        RepeatControlData pdl = new RepeatControlData();
        pdl.moveX = -1.5f;
        pdl.repeat = 50;

        // Create a pattern (or an instruction list) with the control data
        pattern = new RepeatControlData[] { pdr, pdl };
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 enemyPos = transform.position;

        // Process the current instruction in our control data array
        RepeatControlData cd = pattern[patternIndex];
        float deltaX = cd.moveX * horizontalSpeed * Time.deltaTime;
        transform.position += new Vector3(deltaX, 0, 0);


        // Increment the patternIndex so that we move to the next piece of pattern data
        if (repeatIndex >= cd.repeat)
        {
            patternIndex++;
            repeatIndex = 0;
        }
        else
        {
            repeatIndex++;
        }

        // Reset the patternIndex if we are at the end of the instruction array
        if (patternIndex >= pattern.Length)
        {
            patternIndex = 0;
        }

        transform.Translate(Vector3.down * Time.deltaTime * verticalSpeed);
    }
}

