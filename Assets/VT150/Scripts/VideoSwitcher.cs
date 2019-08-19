using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoSwitcher : MonoBehaviour
{

    public GameObject hudVideo;

    public GameObject followVideo;

    public GameObject podium;

    private GvrControllerInputDevice controller;

    private int currentActive = 0;

    // Start is called before the first frame update
    void Start()
    {
        controller = GvrControllerInput.GetDevice(GvrControllerHand.Dominant);
        hudVideo.SetActive(true);
        followVideo.SetActive(false);
        podium.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.GetButtonDown(GvrControllerButton.App))
        {
            currentActive = (currentActive + 1) % 4;
        }
        switch(currentActive)
        {
            case 0:
                hudVideo.SetActive(true);
                followVideo.SetActive(false);
                podium.SetActive(false);
                break;
            case 1:
                hudVideo.SetActive(false);
                followVideo.SetActive(true);
                podium.SetActive(false);
                followVideo.GetComponent<FrontVideo>().enabled = true;
                followVideo.GetComponent<DelayFollowVideo>().enabled = false;
                break;
            case 2:
                hudVideo.SetActive(false);
                followVideo.SetActive(true);
                podium.SetActive(false);
                followVideo.GetComponent<FrontVideo>().enabled = false;
                followVideo.GetComponent<DelayFollowVideo>().enabled = true;
                break;
            case 3:
                hudVideo.SetActive(false);
                followVideo.SetActive(false);
                podium.SetActive(true);
                break;
            default:
                hudVideo.SetActive(true);
                followVideo.SetActive(false);
                podium.SetActive(false);
                break;
        }
    }
}
