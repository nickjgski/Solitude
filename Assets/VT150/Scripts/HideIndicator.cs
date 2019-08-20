using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideIndicator : MonoBehaviour
{

    public Canvas canvas;
    public Renderer object1;
    public Renderer object2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(object1.isVisible && object2.isVisible)
        {
            canvas.enabled = false;
        }
    }
}
