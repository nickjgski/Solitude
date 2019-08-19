using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontVideo : MonoBehaviour
{

    public Camera player;

    private Vector3 lastPos;

    private bool anchored = true;

    // Start is called before the first frame update
    void Start()
    {
        lastPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diff = player.transform.position - lastPos;
        float diffMag = Vector3.Magnitude(diff);
        if(diffMag > 0.005 && anchored)
        {
            anchored = false;
            this.transform.parent = player.transform;
            this.transform.localPosition = new Vector3(2, 0, 4);
            this.transform.localRotation = Quaternion.identity;
        } else
        {
            anchored = true;
            this.transform.parent = null;
        }
        lastPos = player.transform.position;
    }
}
