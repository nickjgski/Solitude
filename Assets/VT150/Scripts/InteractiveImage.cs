using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractiveImage : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IActivatable
{

    //[SerializeField] Camera parentCamera;

    //public bool anchored = true;

    public GameObject imageObject;

    public CanvasGroup imageGroup;

    private GvrControllerInputDevice controller;

    private Vector2 lastTouchPos;

    private bool selected = false;

    private float touchPosXRemap;

    public void OnPointerDown(PointerEventData eventData)
    {
        //ToggleAnchored();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        selected = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        selected = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        //ToggleAnchored();
        controller = GvrControllerInput.GetDevice(GvrControllerHand.Dominant);
    }

    // Update is called once per frame
    void Update()
    {
        if (selected && GvrPointerInputModule.Pointer != null)
        {
            if (!GvrPointerInputModule.Pointer.TriggerDown)
            {
                Drag();
            }
        }

    }

    /*
    private void ToggleAnchored()
    {
        if (anchored)
        {
            AttachToCamera();
        }
        else
        {
            BecomeAnchored();
        }

    }
    

    private void BecomeAnchored()
    {
        // Unparent
        transform.parent = null;
        anchored = true;
    }

    private void AttachToCamera()
    {
        // Reparent and reset transform
        transform.parent = (parentCamera == null) ? null : parentCamera.transform;
        transform.localPosition = new Vector3(0, 0, 1.5f);
        transform.localRotation = Quaternion.identity;
        anchored = false;
    }
    */

    private float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }

    private void OnDrag()
    {
        if (!IsSwiping())
        {
            AdjustAlpha();
        }
    }

    private void Drag()
    {
        // On a new touch, record the start position.
        if (GvrControllerInput.TouchDown)
        {
            lastTouchPos = GvrControllerInput.TouchPosCentered;
            // Otherwise, calculate the touchpad drag distance.
        }
        else if (GvrControllerInput.IsTouching)
        {
            Vector2 currentPosition = GvrControllerInput.TouchPosCentered;
            lastTouchPos = currentPosition;
        }

        OnDrag();
    }

    private bool IsSwiping()
    {
        float xDelta = controller.TouchPos.x - lastTouchPos.x;
        float yDelta = controller.TouchPos.y - lastTouchPos.y;
        lastTouchPos = controller.TouchPos;
        if (xDelta > 0.1f || yDelta > 0.1f)
        {
            return true;
        }
        return false;
    }

    private void AdjustAlpha()
    {
        // Remap touch position to decrease sensitivity in the center of the touchpad.
        touchPosXRemap = map(controller.TouchPos.x, -1, 1, 0.1f, 1);
        imageGroup.alpha = touchPosXRemap;

    }

    public void OnActive()
    {
    }
}
