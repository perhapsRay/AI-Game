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

    private RepeatControlData[] pattern, pattern2;
    private int patternIndex = 0;
    private int repeatIndex = 0;
    private float horizontalSpeed;
    private float verticalSpeed;
    private int health;

    // Use this for initialization
    void Start()
    {
        // Create some control data
        RepeatControlData pdr = new RepeatControlData();
        pdr.moveX = 1f;
        pdr.repeat = 100;

        RepeatControlData pdl = new RepeatControlData();
        pdl.moveX = -1f;
        pdl.repeat = 100;

        // Create a pattern (or an instruction list) with the control data
        ArrayList storage = new ArrayList();

        pattern = new RepeatControlData[] { pdr, pdl, pdl, pdr };
        pattern2 = new RepeatControlData[] { pdl, pdr };


        if (gameObject.tag == "drone")
        {
            health = 1;
            horizontalSpeed = 1f;
            verticalSpeed = 2f;
}

        if (gameObject.tag == "small")
        {
            health = 2;
            horizontalSpeed = 1f;
            verticalSpeed = 4f;
        }


    }

        // Update is called once per frame
        void Update () {

        Vector3 enemyPos = transform.position;
        if (gameObject.tag == "small")
        {
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

