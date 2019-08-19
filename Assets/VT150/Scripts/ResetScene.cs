using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResetScene : MonoBehaviour, IPointerDownHandler
{

    public Canvas resetCanvas;

    public SceneController sceneController;

    private GvrControllerInputDevice controller;

    public void OnPointerDown(PointerEventData eventData)
    {
        String result = eventData.pointerCurrentRaycast.gameObject.name;
        String regexString = Regex.Match(result, @"\d+").Value;
        int sceneNumber = Int32.Parse(regexString);
        sceneController.SetImage(sceneNumber);
        resetCanvas.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GvrControllerInput.GetDevice(GvrControllerHand.Dominant);
        resetCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.GetButtonDown(GvrControllerButton.App))
        {
            sceneController.Reset();
            resetCanvas.enabled = true;
        }
        
    }

}
