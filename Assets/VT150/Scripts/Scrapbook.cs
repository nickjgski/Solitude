using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * This script is to handle the behavior of any scrapbook. In its
 * current implementation the touchpad is used to control flipping
 * through and clicking on images to enlarge them is not supported.
 * The planned implementation is to use swipe gestures to select each
 * image and when reaching the end of a page it would flip to the next.
 */
public class Scrapbook : MonoBehaviour
{

    public TwoDArray[] pics;

    private int numPages;

    public int pageNum;

    public int selected;

    private GvrControllerInputDevice controller;

    private Vector2 lastTouchPos;

    private Vector2 distance;

    // Start is called before the first frame update
    void Start()
    {
        numPages = pics.Length;
        controller = GvrControllerInput.GetDevice(GvrControllerHand.Dominant);
        //pics[1].objects[1].transform.position = pics[1].objects[1].transform.position + new Vector3(0, 0.2f, 0);
    }

    private void Update()
    {
        //Checking for click towards the left
        if(controller.GetButtonDown(GvrControllerButton.TouchPadButton) && controller.TouchPos.x < 0)
        {
            BackPage();
        }
        //Checking for click towards the right
        if (controller.GetButtonDown(GvrControllerButton.TouchPadButton) && controller.TouchPos.x > 0)
        {
            ForwardPage();
        }
        
        /* This will correctly check if a swipe is occurring. Sensitivity 
         * most likely needs adjustment
        distance = lastTouchPos - controller.TouchPos;
        if (distance.magnitude >= 0.1)
        {
            OnSwipe();
        }
        lastTouchPos = controller.TouchPos;
        */
    }

    private void OnSwipe()
    {
        if(controller.TouchPos.x < lastTouchPos.x)
        {
            Forward();
        } else
        {
            Back();
        }
    }

    //Currently hard coded to section 3 and will not lower the other objects. Changing height was also not very obviously
    //visible so should be changed to outline or highlight in some other way
    private void ShowSelect(int selection)
    {
        switch(selection)
        {
            case 0:
                pics[0].objects[0].transform.position = pics[0].objects[0].transform.position + new Vector3(0, 0.2f, 0);
                break;
            case 1:
                pics[0].objects[1].transform.position = pics[0].objects[1].transform.position + new Vector3(0, 0.2f, 0);
                break;
            case 2:
                pics[0].objects[2].transform.position = pics[0].objects[2].transform.position + new Vector3(0, 0.2f, 0);
                break;
            case 3:
                pics[1].objects[0].transform.position = pics[1].objects[0].transform.position + new Vector3(0, 0.2f, 0);
                break;
            case 4:
                pics[1].objects[1].transform.position = pics[1].objects[1].transform.position + new Vector3(0, 0.2f, 0);
                break;
            default:
                break;
        }
    }

    //To be used with swipe to select images
    private void Back()
    {
        if (selected != 0)
        {
            selected--;
            ShowSelect(selected);
            if (pageNum != 0 && selected == 2)
            {
                BackPage();
            }
        }

    }

    //Goes back one page
    private void BackPage()
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

    //To be used with swipe to select images
    private void Forward()
    {
        if (selected != 4)
        {
            selected++;
            ShowSelect(selected);
            if (selected == 3)
            {
                ForwardPage();
            }
        }

    }

    //Goes forward one page
    private void ForwardPage()
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
