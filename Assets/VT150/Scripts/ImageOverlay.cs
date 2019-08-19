using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ImageOverlay : MonoBehaviour, IPointerDownHandler
{

    [SerializeField] Camera parentCamera;

    public Canvas imageCanvas;
    
    public bool anchored = false;

    public List<Sprite> images;

    public Image img;

    private GvrControllerInputDevice controller;

    private void Start()
    {
        controller = GvrControllerInput.GetDevice(GvrControllerHand.Dominant);
        if (!anchored)
        {
            AttachToCamera();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!anchored)
        {
            ToggleAnchored();
        }
        imageCanvas.enabled = false;
        
    }

    public void SetImage(int imgNum)
    {
        Debug.Log(images);
        Debug.Log(img.sprite);
        
        img.sprite = images[imgNum];
        imageCanvas.enabled = true;
    }

    public void ToggleAnchored()
    {
        /* We only need the image to become anchored
        if (anchored)
        {
            AttachToCamera();
        }
        else
        {
        */
            BecomeAnchored();
        //}

    }

    private void BecomeAnchored()
    {
        //Unparent
        transform.parent = null;
        anchored = true;
    }

    public void AttachToCamera()
    {
        // Reparent and reset transform
        transform.parent = (parentCamera == null) ? null : parentCamera.transform;
        transform.localPosition = new Vector3(0, 0, 1.5f);
        transform.localRotation = Quaternion.identity;
        anchored = false;
    }

}
