using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PositionDebug : MonoBehaviour
{

    public TextMeshProUGUI text;

    public Camera player;

    private Vector3 forward;

    private Vector3 world;

    // Start is called before the first frame update
    void Start()
    {
        forward = player.transform.forward + new Vector3(0, 0, 4);
        world = player.transform.TransformPoint(Vector3.forward * 4);
        text.text = forward.ToString() + "\n" + world.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        forward = player.transform.forward + new Vector3(0, 0, 4);
        world = player.transform.TransformPoint(Vector3.forward * 4);
        text.text = forward.ToString() + "\n" + world.ToString();
    }
}
