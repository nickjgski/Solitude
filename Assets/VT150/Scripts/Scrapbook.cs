using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrapbook : MonoBehaviour
{

    public TwoDArray[] pics;

    private int numPages;

    public int pageNum;

    private GvrControllerInputDevice controller;

    // Start is called before the first frame update
    void Start()
    {
        numPages = pics.Length;
        controller = GvrControllerInput.GetDevice(GvrControllerHand.Dominant);
    }

    private void Update()
    {
        if(controller.GetButtonDown(GvrControllerButton.TouchPadButton) && controller.TouchPos.x < 0)
        {
            Back();
        }
        if (controller.GetButtonDown(GvrControllerButton.TouchPadButton) && controller.TouchPos.x > 0)
        {
            Forward();
        }
    }

    public void Back()
    {

        if (pageNum != 0)
        {
            foreach (GameObject image in pics[pageNum].objects)
            {
                image.SetActive(false);
            }
            pageNum--;
            foreach (GameObject image in pics[pageNum].objects)
            {
                image.SetActive(true);
            }
        }

    }

    public void Forward()
    {
        if (pageNum != numPages - 1)
        {
            foreach (GameObject image in pics[pageNum].objects)
            {
                image.SetActive(false);
            }
            pageNum++;
            foreach (GameObject image in pics[pageNum].objects)
            {
                image.SetActive(true);
            }
        }

    }

}
