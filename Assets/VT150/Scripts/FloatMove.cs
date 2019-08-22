using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatMove : MonoBehaviour
{

    float t;
    Vector3 startPosition;
    Vector3 targetPos;
    Quaternion startOrientation;
    Quaternion targetOrientation;
    float timeToReachTarget;

    void Start()
    {
        startPosition = targetPos = transform.position;
        startOrientation = targetOrientation = transform.rotation;
    }

    void Update()
    {
        t += Time.deltaTime / timeToReachTarget;
        transform.position = Vector3.Lerp(startPosition, targetPos, t);
        transform.rotation = Quaternion.Lerp(startOrientation, targetOrientation, t);
    }

    public void SetDestination(Vector3 destination, Quaternion orientation, float time)
    {
        t = 0;
        startPosition = transform.position;
        startOrientation = transform.rotation;
        timeToReachTarget = time;
        targetPos = destination;
        targetOrientation = orientation;
    }

}
