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

    private RepeatControlData[] pattern, pattern2, pattern3, pattern4;
    private int patternIndex = 0;
    private int repeatIndex = 0;
    private float horizontalSpeed;
    private float verticalSpeed;
    private int health;
    public GameObject explosion;
    public Transform body;


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

        pattern = new RepeatControlData[] {pdr, pdl, pdl, pdr};
        pattern2 = new RepeatControlData[] {pdr, pdr};
        pattern3 = new RepeatControlData[] {pdr, pdl};
        pattern4 = new RepeatControlData[] {pdl, pdr};

        //Setting Health and Speed
        if (gameObject.tag == "drone")
        {
            health = 1;
            verticalSpeed = 6f;
        }
        if (gameObject.tag == "small")
        {
            health = 2;
            horizontalSpeed = 1f;
            verticalSpeed = 5f;
        }
        if (gameObject.tag == "wing")
        {
            health = 2;
            horizontalSpeed = 3f;
            verticalSpeed = 3f;
        }
        if (gameObject.tag == "crossL")
        {
            health = 2;
            horizontalSpeed = 3f;
            verticalSpeed = 1f;
        }
        if (gameObject.tag == "crossR")
        {
            health = 2;
            horizontalSpeed = 3f;
            verticalSpeed = 1f;
        }
        if (gameObject.tag == "boss striker")
        {
            horizontalSpeed = 1f;
        }
    }

        // Update is called once per frame
        void Update ()
    {

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
        if (gameObject.tag == "wing")
        {
            // Process the current instruction in our control data array
            RepeatControlData cd = pattern2[patternIndex];
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
            if (patternIndex >= pattern2.Length)
            {
                patternIndex = 0;
            }
        }
        if (gameObject.tag == "boss striker")
        {
            // Process the current instruction in our control data array
            RepeatControlData cd = pattern4[patternIndex];
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
            if (patternIndex >= pattern4.Length)
            {
                patternIndex = 0;
            }
        }





        transform.Translate(Vector3.down * Time.deltaTime * verticalSpeed);
             Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
             if (transform.position.y < min.y)
             {
                 Destroy(gameObject);
             }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet (Clone)")
        {
            health--;
            Destroy(collision.gameObject);
            if (health <= 0)
            {
                Instantiate(explosion, body.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                score.scoreAmount += 10;
                Destroy(gameObject);
            }
        }
    }
}

