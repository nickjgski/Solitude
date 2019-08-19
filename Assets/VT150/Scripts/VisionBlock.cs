using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisionBlock : MonoBehaviour
{

    public Image image;

    private bool fadingIn = false;

    // Start is called before the first frame update
    void Start()
    {

        image.color = new Color(0, 0, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (fadingIn)
        {
            image.CrossFadeAlpha(1, 2.0f, false);
            //Debug.Log("Fading In");
        }
        if (!fadingIn)
        {
            image.CrossFadeAlpha(0, 2.0f, false);
            //Debug.Log("Fading Out");
        }
        //Debug.Log(fadingIn);
    }

    public void FadeIn()
    {
        fadingIn = true;
    }

    public void FadeOut()
    {
        fadingIn = false;
    }
}
