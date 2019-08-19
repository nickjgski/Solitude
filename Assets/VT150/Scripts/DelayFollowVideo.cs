using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayFollowVideo : MonoBehaviour
{

    public Camera player;

    float t;
    Vector3 startPosition;
    Vector3 target;
    Vector3 lastPos;
    float timeToReachTarget;

    void Start()
    {
        startPosition = target = transform.position;
        lastPos = player.transform.position;
    }

    void Update()
    {
        Vector3 diff = player.transform.position - lastPos;
        float diffMag = Vector3.Magnitude(diff);
        if (diffMag > 0.0001)
        {
            Vector3 calcPos = player.transform.TransformPoint(Vector3.forward * 4 + Vector3.right * 1.5f);
            SetDestination(calcPos, 1.5f);
        }
        t += Time.deltaTime / timeToReachTarget;
        transform.position = Vector3.Lerp(startPosition, target, t);
        lastPos = player.transform.position;
    }

    public void SetDestination(Vector3 destination, float time)
    {

        t = 0;
        startPosition = transform.position;
        timeToReachTarget = time;
        target = destination;

    }

}
