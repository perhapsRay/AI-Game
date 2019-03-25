﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicInterception : MonoBehaviour
{

    public GameObject target;
    public float speed = 3.0f;
    public float T = 10.0f;

    private Vector3 targetLastPosition;
    private Vector3 targetVelocity;
    private Vector3 predictedPosition;
    private Vector3 velocity;
    private Vector3 current;

    private Vector3 closing;
    private Vector3 vecDifference;


    // Use this for initialization
    void Start()
    {
        targetLastPosition = target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        UpdateTargetVelocity();
        CalculatePredictedPosition();
        
        // Find the range to close vector
        Vector3 rangeToClose = predictedPosition - transform.position;

        // Draw this vector at the position of the enemy
        Debug.DrawRay(transform.position, rangeToClose, Color.cyan);

        // Get the distance to the target
        float distance = rangeToClose.magnitude;

        // How far do we move each frame.
        // speedDelta is how much we want to move in 1 sec
        // We need to scale this down to how much we move in a frame
        // Time.deltaTime is the time elapsed since the last frame (typically 1/60s)
        float speedDelta = speed * Time.deltaTime;

        // Only move in the direction of the player if our distance
        // to the player is greater than how much we will move in the frame
        if (distance > speedDelta)
        {
            // Find our direction to the 
            Vector3 normalizedRangeToClose = rangeToClose.normalized;

            // Draw this vector at the position of the enemy
            Debug.DrawRay(transform.position, normalizedRangeToClose, Color.green);

            // Multipling the speedDelta by the normalizedRangeToClose
            // will give us our displacement vector.
            Vector3 delta = speedDelta * normalizedRangeToClose;

            // Tranform our enemy in the direction of our player
            transform.Translate(delta);
        }


    }

    void CalculatePredictedPosition()
    {
        current = transform.position;
        //Closing
        closing = targetVelocity - velocity;

        //Distance
        vecDifference = targetLastPosition - current;

        if (closing == Vector3.zero)
        {
            T = 10.0f;
        }
        else
        {
            T = vecDifference.magnitude / closing.magnitude;
        }

        Debug.DrawRay(target.transform.position, targetVelocity.normalized, Color.white);

        if (Input.GetKey(KeyCode.P))
        {
            T += 1.0f;
        }
        if (Input.GetKey(KeyCode.O))
        {
            T -= 1.0f;
        }

        predictedPosition = target.transform.position + targetVelocity * T;
    }

    void UpdateTargetVelocity()
    {
        // Calculate the velocity i.e. how much the player has moved
        // in a frame.
        Vector3 targetCurrentPosition = target.transform.position;
        targetVelocity = targetCurrentPosition - targetLastPosition;

        // Update the last position
        targetLastPosition = targetCurrentPosition;

    }

    private void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(predictedPosition, 0.2f);
    }
}
