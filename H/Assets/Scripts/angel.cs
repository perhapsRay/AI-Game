using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angel : MonoBehaviour {

    public GameObject slash;
    public Transform body;
    public AngelState state = AngelState.IDLE;

    [SerializeField]
    Transform[] waypoints;

    [SerializeField]
    float speed = 2f;

    int waypointIndex = 0;
    public int health;


    public enum AngelState
    {
        IDLE,
        ATTACK,
        DESPERATE
    };

    // Use this for initialization
    void Start () {
        transform.position = waypoints[waypointIndex].transform.position;
        health = 100;

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
            case AngelState.DESPERATE:
                ProcessDesperateState();
                CheckForTransitionFromDesperate();
                break;
        }

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
        if (health < 90)
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
        if(health < 30)
        {
            state = AngelState.DESPERATE;
            ProcessDesperateState();
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
            if (shootchance > 50)
            {
                Instantiate(slash, body.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
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
                enemySpawner.time = 0;
                Destroy(gameObject);
            }
        }
    }
}
