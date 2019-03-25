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

    private RepeatControlData[] pattern1, pattern2;
    private int patternIndex = 0;
    private int repeatIndex = 0;
    private float horizontalSpeed = 1.5f;
    private float verticalSpeed = 2.5f;
    int health = 3;

    // Use this for initialization
    void Start () {
        // Create some control data
        RepeatControlData pdr = new RepeatControlData();
        pdr.moveX = 1.5f;
        pdr.repeat = 60;

        RepeatControlData pdl = new RepeatControlData();
        pdl.moveX = -1.5f;
        pdl.repeat = 120;

        // Create a pattern (or an instruction list) with the control data
        pattern1 = new RepeatControlData[] { pdr, pdl, pdr };
        pattern2 = new RepeatControlData[] { pdl, pdr, pdl };
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 enemyPos = transform.position;



        // Process the current instruction in our control data array

        if (enemyPos.x < 0)
        {
            RepeatControlData cd = pattern1[patternIndex];
            float deltaX = cd.moveX * horizontalSpeed * Time.deltaTime;
            transform.position += new Vector3(deltaX, 0, 0);

            if (repeatIndex >= cd.repeat)
            {
                patternIndex++;
                repeatIndex = 0;
            }
            else
            {
                repeatIndex++;
            }
        }
        else
        {
            RepeatControlData cd = pattern2[patternIndex];
            float deltaX = cd.moveX * horizontalSpeed * Time.deltaTime;
            transform.position += new Vector3(deltaX, 0, 0);

            if (repeatIndex >= cd.repeat)
            {
                patternIndex++;
                repeatIndex = 0;
            }
            else
            {
                repeatIndex++;
            }
        }
        


        // Increment the patternIndex so that we move to the next piece of pattern data
        

        // Reset the patternIndex if we are at the end of the instruction array

        if (enemyPos.x < 0)
        {
            if (patternIndex >= pattern1.Length)
            {
                patternIndex = 0;
            }
        }
        else
        {
            if (patternIndex >= pattern2.Length)
            {
                patternIndex = 0;
            }
        }

        transform.Translate(Vector3.down * Time.deltaTime * verticalSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet (Clone)")
        {
            health--;
            Destroy(collision.gameObject);
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

