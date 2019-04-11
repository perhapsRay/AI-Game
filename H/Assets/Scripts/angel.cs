using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class angel : MonoBehaviour {

    public GameObject slash;
    public Transform body;
    public Transform defend;
    public GameObject shield;
    public AngelState state = AngelState.IDLE;
    public bool shieldCreate = false;
    public static bool shieldHealth = true;
    public GameObject explosion;

    [SerializeField]
    Transform[] waypoints;

    [SerializeField]
    float speed = 2f;


    int waypointIndex = 0;
    public static float bosshealth = 1f;


    public enum AngelState
    {
        IDLE,
        ATTACK,
        DEFEND,
        DESPERATE
    };

    // Use this for initialization
    void Start () {
        transform.position = waypoints[waypointIndex].transform.position;
        //bosshealth = 1f;

        InvokeRepeating("Shoot", 1f, 1f);
    }
	
	// Update is called once per frame
	void Update () {

        switch (state)
        {
            case AngelState.IDLE:
                ProcessIdleState();
                CheckForTransitionFromIdle();
                break;
            case AngelState.ATTACK:
                ProcessAttackState();
                CheckForTransitionFromAttack();
                break;
            case AngelState.DEFEND:
                ProcessDefendState();
                CheckForTransitionFromDefend();
                break;
            case AngelState.DESPERATE:
                ProcessDesperateState();
                CheckForTransitionFromDesperate();
                break;
        }
        Debug.Log(bosshealth);

        //Move();
    }

    void ProcessIdleState()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position,
           speed * Time.deltaTime);

        if (transform.position == waypoints[waypointIndex].transform.position)
        {
            waypointIndex += 1;
        }

        if (waypointIndex == 2)
        {
            waypointIndex = 1;
        }
    }

    void CheckForTransitionFromIdle()
    {
        if (bosshealth <= .9f)
        {
            state = AngelState.ATTACK;
            ProcessAttackState();
        }
    }

    void ProcessAttackState()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position,
           speed * Time.deltaTime);

        if (transform.position == waypoints[waypointIndex].transform.position)
        {
            waypointIndex += 1;
        }

        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 1;
        }

    }

    void CheckForTransitionFromAttack()
    {
        //if (shieldHealth == true)
        //{
        //    if (bosshealth < .3f)
        //    {
        //        state = AngelState.DEFEND;
        //        ProcessDefendState();
        //    }
        //}
        //else if (shieldHealth == false)
        //{
        //    if (bosshealth < .3f)
        //    {
        //        state = AngelState.DESPERATE;
        //        ProcessDesperateState();
        //    }
        //}

        if(bosshealth <= .3f)
        {
            if (shieldHealth == true)
            {
                state = AngelState.DEFEND;
                ProcessDefendState();
            }
            else if (shieldHealth == false)
            {
                state = AngelState.DESPERATE;
                ProcessDesperateState();
            }
        }

    }

    void ProcessDefendState()
    {

        if (!shieldCreate)
        {
            var myShield = Instantiate(shield, defend.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            myShield.transform.parent = gameObject.transform;
            shieldCreate = true;
        }

        bosshealth += .001f;

        //transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position,
        //   speed * Time.deltaTime);

        //if (transform.position == waypoints[waypointIndex].transform.position)
        //{
        //    waypointIndex += 1;
        //}

        //if (waypointIndex == 2)
        //{
        //    waypointIndex = 1;
        //}

        //if (shieldScript.shieldHP <= 0)
        //{
        //    shieldHealth = false;
        //}

    }

    void CheckForTransitionFromDefend()
    {
        if (bosshealth >= .9f)
            {
            if (shieldHealth == true)
            {
                shieldCreate = false;
                Destroy(shield);
                state = AngelState.ATTACK;
                ProcessAttackState();
            }
            else
            {
                state = AngelState.ATTACK;
                ProcessAttackState();
            }
        }
        else if (shieldHealth == false)
        {
            if(bosshealth >= .4f && bosshealth <= .9f)
            {
                state = AngelState.ATTACK;
                ProcessAttackState();
            }
            else
            {
                state = AngelState.DESPERATE;
                ProcessDesperateState();
            }
        }
    }

    void ProcessDesperateState()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position,
           speed * Time.deltaTime);

        if (transform.position == waypoints[waypointIndex].transform.position)
        {
            waypointIndex += 1;
        }

        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 1;
        }

           speed = 6f;

        
    }

    void CheckForTransitionFromDesperate()
    {

    }

    //void Move()
    //{
    //    if (health < 90)
    //    {
    //        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position,
    //        speed * Time.deltaTime);

    //        if (transform.position == waypoints[waypointIndex].transform.position)
    //        {
    //            waypointIndex += 1;
    //        }

    //        if (waypointIndex == waypoints.Length)
    //        {
    //            waypointIndex = 1;
    //        }

    //        if(health < 60)
    //        {
    //            speed = 3f;
    //            if (health < 50)
    //            {
    //                speed = 4f;
    //                if (health < 20)
    //                {
    //                    speed = 6f;
    //                }
    //            }
    //        }
    //    }
    //else
    //{
    //    transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position,
    //    speed * Time.deltaTime);

    //    if (transform.position == waypoints[waypointIndex].transform.position)
    //    {
    //        waypointIndex += 1;
    //    }

    //    if (waypointIndex == 2)
    //    {
    //        waypointIndex = 1;
    //    }
    //}
    //}

    void Shoot()
    {
        int shootchance = Random.Range(0, 100);
        if (state == AngelState.ATTACK)
        {
            if (shootchance > 80)
             {
            
                Instantiate(slash, body.position, Quaternion.Euler(new Vector3(0, 0, 0)));
             }
        }
        else if (state == AngelState.DESPERATE)
        {
            if (shootchance > 30)
            {
                Instantiate(slash, body.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet (Clone)")
        {
            bosshealth -= 0.01f;
            Destroy(collision.gameObject);
            if (bosshealth <= 0)
            {
                Instantiate(explosion, body.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                enemySpawner.time = 0;
                Destroy(gameObject);
            }
        }
    }
}
